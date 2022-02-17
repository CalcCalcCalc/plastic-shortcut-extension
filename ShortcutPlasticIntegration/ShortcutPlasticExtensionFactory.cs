using Codice.Client.IssueTracker;

namespace ShortcutPlasticIntegration;

public class ShortcutPlasticExtensionFactory : IPlasticIssueTrackerExtensionFactory
{
    public IssueTrackerConfiguration GetConfiguration(IssueTrackerConfiguration? storedConfiguration)
    {
        List<IssueTrackerConfigurationParameter> parameters = new List<IssueTrackerConfigurationParameter>();

        ExtensionWorkingMode workingMode = GetWorkingMode(storedConfiguration);

        string? user = GetValidParameterValue(storedConfiguration, ShortcutPlasticExtension.USER_KEY, "1");

        string? prefix = GetValidParameterValue(storedConfiguration, ShortcutPlasticExtension.BRANCH_PREFIX_KEY, "shortcut");

        IssueTrackerConfigurationParameter userIdParam = new IssueTrackerConfigurationParameter()
        {
            Name = ShortcutPlasticExtension.USER_KEY,
            Value = GetValidParameterValue(storedConfiguration, ShortcutPlasticExtension.USER_KEY, "1"),
            Type = IssueTrackerConfigurationParameterType.User,
            IsGlobal = false
        };

        IssueTrackerConfigurationParameter branchPrefixParam = new IssueTrackerConfigurationParameter()
        {
            Name = ShortcutPlasticExtension.BRANCH_PREFIX_KEY,
            Value = GetValidParameterValue(storedConfiguration, ShortcutPlasticExtension.BRANCH_PREFIX_KEY, "scm"),
            Type = IssueTrackerConfigurationParameterType.BranchPrefix,
            IsGlobal = true
        };
        
        parameters.Add(userIdParam);
        parameters.Add(branchPrefixParam);

        return new IssueTrackerConfiguration(workingMode, parameters);
    }

    private string? GetValidParameterValue(IssueTrackerConfiguration? configuration, string paramName, string? defaultValue)
    {
        string? configValue = configuration?.GetValue(paramName);
        if (string.IsNullOrEmpty(configValue))
            return defaultValue;
        return configValue;
    }

    ExtensionWorkingMode GetWorkingMode(IssueTrackerConfiguration? configuration)
    {
        if (configuration == null)
            return ExtensionWorkingMode.TaskOnBranch;

        if (configuration.WorkingMode == ExtensionWorkingMode.None)
            return ExtensionWorkingMode.TaskOnBranch;

        return configuration.WorkingMode;
    }

    public IPlasticIssueTrackerExtension GetIssueTrackerExtension(IssueTrackerConfiguration configuration)
    {
        return new ShortcutPlasticExtension(configuration);
    }

    public string GetIssueTrackerName()
    {
        return "Shortcut Issue Tracker";
    }
}