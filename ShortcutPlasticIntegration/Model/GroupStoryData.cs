using System.Text.Json;

namespace ShortcutPlasticIntegration.Model;

public class GroupStoryData
{
    public string app_url { get; set; }
    public string description { get; set; }
    public bool archived { get; set; }
    public string entity_type { get; set; }
    public int days_to_thermometer { get; set; }
    public string color { get; set; }
    public int workflow_id { get; set; }
    public string name { get; set; }
    public DateTime start_time { get; set; }
    public DateTime updated_at { get; set; }
    public List<object> follower_ids { get; set; }
    public object external_id { get; set; }
    public int id { get; set; }
    public bool show_thermometer { get; set; }
    public int team_id { get; set; }
    public int iteration_length { get; set; }
    public object abbreviation { get; set; }
    public Stats stats { get; set; }
    public DateTime created_at { get; set; }

    public class Stats
    {
        public int num_stories { get; set; }
        public int num_points { get; set; }
        public int num_related_documents { get; set; }
    }
}





