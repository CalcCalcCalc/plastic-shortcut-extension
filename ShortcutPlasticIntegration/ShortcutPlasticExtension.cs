/*
 * Free to copy and distribute without alteration
 * Licensed under GPLv3
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 * By Alec Stone
 * For more info
 * https://www.plasticscm.com/documentation/extensions/plastic-scm-version-control-task-and-issue-tracking-guide
 * https://shortcut.com/api/rest/v3
 *
 * Note:  
 */

using System.Diagnostics;
using System.Text.Json;
using Codice.Client.IssueTracker;
using log4net;
using ShortcutPlasticIntegration.Model;

namespace ShortcutPlasticIntegration;

public class ShortcutPlasticExtension : IPlasticIssueTrackerExtension
{
    internal const string BRANCH_PREFIX_KEY = "";
    internal const string USER_KEY = "";

    private const string PROJECT_NAME = "API";
    private const string GROUP_NAME = "DEVELOPMENT";
    
    private const string ALL_PROJECTS_URL = "https://api.app.shortcut.com/api/v3/projects";
    private const string ALL_GROUPS_URL = "https://api.app.shortcut.com/api/v3/groups";
    private const string ALL_STORIES_URL = "https://api.app.shortcut.com/api/v3/projects/{0}/stories";
    private const string STORIES_BY_GROUP_URL = "https://api.app.shortcut.com/api/v3/groups/{0}/stories";
    private const string STORY_URL = "https://api.app.shortcut.com/api/v3/stories/{0}";
    
    private const string DEBUG_SHORTCUT_API_KEY = "6209181d-2615-4a29-94db-dc36d9e4d7b8";
    
    private readonly IssueTrackerConfiguration _config;

    static HttpClient _client = new();
    private static readonly ILog Log = LogManager.GetLogger("ShortcutPlasticExtension");

    internal ShortcutPlasticExtension(IssueTrackerConfiguration config)
    {
        _config = config;
        _client.DefaultRequestHeaders.Add("Shortcut-Token", DEBUG_SHORTCUT_API_KEY);
        Log.Info("Shortcut issue tracker is initialised");
        GetPendingTasks("Development");
    }

    public void Connect()
    {
        // No action needed
    }

    public void Disconnect()
    {
        // No action needed
    }

    public string GetExtensionName()
    {
        return "Shortcut Plastic extension (Made by Alec Stone)";
    }

    // use groups instead of assignee
    public List<PlasticTask?> GetPendingTasks(string group)
    {
        if (string.IsNullOrEmpty(group))
        {
            return new List<PlasticTask?>();
        }
        
        //Chain the three requests

        return QueryServiceForTasks(string.Format(STORIES_BY_GROUP_URL, group));
    }

    public List<PlasticTask?> GetPendingTasks()
    {
        return QueryServiceForTasks(ALL_STORIES_URL);
    }

    public Dictionary<string, PlasticTask?> GetTasksForBranches(List<string> fullBranchNames)
    {
        Dictionary<string, PlasticTask?> result = new Dictionary<string, PlasticTask?>();
        foreach (string fullBranchName in fullBranchNames)
        {
            string taskId = GetTaskIdFromBranchName(GetBranchName(fullBranchName));
            result.Add(fullBranchName, LoadSingleTask(taskId));
        }
        return result;
    }
    
    public void OpenTaskExternally(string taskId)
    {
        Process.Start($"https://www.google.com/search?q={taskId}");
    }

    public List<PlasticTask> LoadTasks(List<string> taskIds)
    {
        List<PlasticTask> result = new List<PlasticTask>();

        foreach (string taskId in taskIds)
        {
            PlasticTask? loadedTask = LoadSingleTask(taskId);
            if (loadedTask == null)
            {
                continue;
            }
            result.Add(loadedTask);
        }

        return result;
    }

    public PlasticTask? GetTaskForBranch(string fullBranchName)
    {
        return LoadSingleTask(
            GetTaskIdFromBranchName(
                GetBranchName(fullBranchName)));
    }
    
    public bool TestConnection(IssueTrackerConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    public void LogCheckinResult(PlasticChangeset changeset, List<PlasticTask> tasks)
    {
        throw new NotImplementedException();
    }

    public void UpdateLinkedTasksToChangeset(PlasticChangeset changeset, List<string> tasks)
    {
        throw new NotImplementedException();
    }

    public void MarkTaskAsOpen(string taskId, string assignee)
    {
        throw new NotImplementedException();
    }

    private string GetBranchName(string fullBranchName)
    {
        int lastSeparatorIndex = fullBranchName.LastIndexOf('/');

        if (lastSeparatorIndex < 0)
        {
            return fullBranchName;
        }

        if (lastSeparatorIndex == fullBranchName.Length - 1)
        {
            return String.Empty;
        }

        return fullBranchName.Substring(lastSeparatorIndex + 1);
    }

    private string GetTaskIdFromBranchName(String branchName)
    {
        string prefix = _config.GetValue(BRANCH_PREFIX_KEY);
        if (string.IsNullOrEmpty(prefix))
        {
            return branchName;
        }

        if (!branchName.StartsWith(branchName) || branchName == prefix)
        {
            return string.Empty;
        }

        return branchName.Substring(prefix.Length);
    }
    
    private PlasticTask? LoadSingleTask(string taskId)
    {
        if (string.IsNullOrEmpty(taskId))
            return null;

        string uri = string.Format(STORY_URL, taskId);
        string resultJson = Task.Run(
            () => PerformJsonRequest(uri)).Result;
        
        return BuildTaskFromJson(
            JsonSerializer.Deserialize<GroupStoryData>(resultJson));
    }

    private List<PlasticTask?> QueryServiceForTasks(string uri)
    {
        List<PlasticTask?> result = new List<PlasticTask?>();
        string jsonResult = Task.Run(
            () => PerformJsonRequest(uri)).Result;

        GroupStoryData[]? deserializedServiceData =
            JsonSerializer.Deserialize<GroupStoryData[]>(jsonResult);

        if (deserializedServiceData != null)
        {
            foreach (GroupStoryData serviceData in deserializedServiceData)
            {
                result.Add(BuildTaskFromJson(serviceData));
            }
        }

        return result;
    }

    private async Task<string> PerformJsonRequest(string targetUri)
    {
        try
        {
            HttpResponseMessage response = await _client.GetAsync(targetUri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            Log.ErrorFormat("Unable to perform request on URI {0}: {1}", targetUri, e.Message);
            Log.DebugFormat("Stack trace:{0}{1}", Environment.NewLine, e.StackTrace);
            return string.Empty;
        }
    }

    private PlasticTask? BuildTaskFromJson(GroupStoryData? jsonData)
    {
        if (jsonData == null)
        {
            return null;
        }

        return new PlasticTask()
        {
            Id = jsonData.id.ToString(),
            Title = jsonData.name,
            Description = jsonData.description,
            Status = "working"
        };
    }
}