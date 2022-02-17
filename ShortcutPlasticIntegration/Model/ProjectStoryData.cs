namespace ShortcutPlasticIntegration.Model;

public class ProjectStoryData
{
    public string app_url { get; set; }
    public bool archived { get; set; }
    public bool blocked { get; set; }
    public bool blocker { get; set; }
    public List<int> comment_ids { get; set; }
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
    public List<int> file_ids { get; set; }
    public List<string> follower_ids { get; set; }
    public string group_id { get; set; }
    public List<string> group_mention_ids { get; set; }
    public int id { get; set; }
    public int iteration_id { get; set; }
    public List<int> label_ids { get; set; }
    public List<Label> labels { get; set; }
    public int lead_time { get; set; }
    public List<int> linked_file_ids { get; set; }
    public List<string> member_mention_ids { get; set; }
    public List<string> mention_ids { get; set; }
    public DateTime moved_at { get; set; }
    public string name { get; set; }
    public int num_tasks_completed { get; set; }
    public List<string> owner_ids { get; set; }
    public int position { get; set; }
    public List<int> previous_iteration_ids { get; set; }
    public int project_id { get; set; }
    public string requested_by_id { get; set; }
    public bool started { get; set; }
    public DateTime started_at { get; set; }
    public DateTime started_at_override { get; set; }
    public Stats stats { get; set; }
    public List<StoryLink> story_links { get; set; }
    public string story_template_id { get; set; }
    public string story_type { get; set; }
    public List<int> task_ids { get; set; }
    public DateTime updated_at { get; set; }
    public int workflow_id { get; set; }
    public int workflow_state_id { get; set; }
    
    public class CustomField
    {
        public string field_id { get; set; }
        public string value { get; set; }
        public string value_id { get; set; }
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
}