namespace ShortcutPlasticIntegration.Model;

public class StoryData
{
    public string app_url { get; set; }
    public bool archived { get; set; }
    public bool blocked { get; set; }
    public bool blocker { get; set; }
    public List<Branch> branches { get; set; }
    public List<Comment> comments { get; set; }
    public List<Commit> commits { get; set; }
    public bool completed { get; set; }
    public DateTime completed_at { get; set; }
    public DateTime completed_at_override { get; set; }
    public DateTime created_at { get; set; }
    public List<CustomField> custom_fields { get; set; }
    public int cycle_time { get; set; }
    public DateTime deadline { get; set; }
    public string description { get; set; }
    public string entity_type { get; set; }
    public int epic_id { get; set; }
    public int estimate { get; set; }
    public string external_id { get; set; }
    public List<object> external_links { get; set; }
    public List<File> files { get; set; }
    public List<string> follower_ids { get; set; }
    public string group_id { get; set; }
    public List<string> group_mention_ids { get; set; }
    public int id { get; set; }
    public int iteration_id { get; set; }
    public List<int> label_ids { get; set; }
    public List<Label> labels { get; set; }
    public int lead_time { get; set; }
    public List<LinkedFile> linked_files { get; set; }
    public List<string> member_mention_ids { get; set; }
    public List<string> mention_ids { get; set; }
    public DateTime moved_at { get; set; }
    public string name { get; set; }
    public List<string> owner_ids { get; set; }
    public int position { get; set; }
    public List<int> previous_iteration_ids { get; set; }
    public int project_id { get; set; }
    public List<PullRequest> pull_requests { get; set; }
    public string requested_by_id { get; set; }
    public bool started { get; set; }
    public DateTime started_at { get; set; }
    public DateTime started_at_override { get; set; }
    public Stats stats { get; set; }
    public List<StoryLink> story_links { get; set; }
    public string story_template_id { get; set; }
    public string story_type { get; set; }
    public List<Task> tasks { get; set; }
    public DateTime updated_at { get; set; }
    public int workflow_id { get; set; }
    public int workflow_state_id { get; set; }

    public class VcsLabel
    {
        public string color { get; set; }
        public string description { get; set; }
        public string entity_type { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class PullRequest
    {
        public int branch_id { get; set; }
        public string branch_name { get; set; }
        public string build_status { get; set; }
        public bool closed { get; set; }
        public DateTime created_at { get; set; }
        public bool draft { get; set; }
        public string entity_type { get; set; }
        public int id { get; set; }
        public bool merged { get; set; }
        public int num_added { get; set; }
        public int num_commits { get; set; }
        public int num_modified { get; set; }
        public int num_removed { get; set; }
        public int number { get; set; }
        public int repository_id { get; set; }
        public string review_status { get; set; }
        public int target_branch_id { get; set; }
        public string target_branch_name { get; set; }
        public string title { get; set; }
        public DateTime updated_at { get; set; }
        public string url { get; set; }
        public List<VcsLabel> vcs_labels { get; set; }
    }

    public class Branch
    {
        public DateTime created_at { get; set; }
        public bool deleted { get; set; }
        public string entity_type { get; set; }
        public int id { get; set; }
        public List<int> merged_branch_ids { get; set; }
        public string name { get; set; }
        public bool persistent { get; set; }
        public List<PullRequest> pull_requests { get; set; }
        public int repository_id { get; set; }
        public DateTime updated_at { get; set; }
        public string url { get; set; }
    }

    public class Comment
    {
        public string app_url { get; set; }
        public string author_id { get; set; }
        public DateTime created_at { get; set; }
        public bool deleted { get; set; }
        public string entity_type { get; set; }
        public string external_id { get; set; }
        public List<string> group_mention_ids { get; set; }
        public int id { get; set; }
        public List<string> member_mention_ids { get; set; }
        public List<string> mention_ids { get; set; }
        public int parent_id { get; set; }
        public int position { get; set; }
        public int story_id { get; set; }
        public string text { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class AuthorIdentity
    {
        public string entity_type { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Commit
    {
        public string author_email { get; set; }
        public string author_id { get; set; }
        public AuthorIdentity author_identity { get; set; }
        public DateTime created_at { get; set; }
        public string entity_type { get; set; }
        public string hash { get; set; }
        public int id { get; set; }
        public List<int> merged_branch_ids { get; set; }
        public string message { get; set; }
        public int repository_id { get; set; }
        public DateTime timestamp { get; set; }
        public DateTime updated_at { get; set; }
        public string url { get; set; }
    }

    public class CustomField
    {
        public string field_id { get; set; }
        public string value { get; set; }
        public string value_id { get; set; }
    }

    public class File
    {
        public string content_type { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public string entity_type { get; set; }
        public string external_id { get; set; }
        public string filename { get; set; }
        public List<string> group_mention_ids { get; set; }
        public int id { get; set; }
        public List<string> member_mention_ids { get; set; }
        public List<string> mention_ids { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public List<int> story_ids { get; set; }
        public string thumbnail_url { get; set; }
        public DateTime updated_at { get; set; }
        public string uploader_id { get; set; }
        public string url { get; set; }
    }

    public class Label
    {
        public string app_url { get; set; }
        public bool archived { get; set; }
        public string color { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public string entity_type { get; set; }
        public string external_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class LinkedFile
    {
        public string content_type { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public string entity_type { get; set; }
        public List<string> group_mention_ids { get; set; }
        public int id { get; set; }
        public List<string> member_mention_ids { get; set; }
        public List<string> mention_ids { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public List<int> story_ids { get; set; }
        public string thumbnail_url { get; set; }
        public string type { get; set; }
        public DateTime updated_at { get; set; }
        public string uploader_id { get; set; }
        public string url { get; set; }
    }

    public class Stats
    {
        public int num_related_documents { get; set; }
    }

    public class StoryLink
    {
        public DateTime created_at { get; set; }
        public string entity_type { get; set; }
        public int id { get; set; }
        public int object_id { get; set; }
        public int subject_id { get; set; }
        public string type { get; set; }
        public DateTime updated_at { get; set; }
        public string verb { get; set; }
    }

    public class Task
    {
        public bool complete { get; set; }
        public DateTime completed_at { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public string entity_type { get; set; }
        public string external_id { get; set; }
        public List<string> group_mention_ids { get; set; }
        public int id { get; set; }
        public List<string> member_mention_ids { get; set; }
        public List<string> mention_ids { get; set; }
        public List<string> owner_ids { get; set; }
        public int position { get; set; }
        public int story_id { get; set; }
        public DateTime updated_at { get; set; }
    }
}