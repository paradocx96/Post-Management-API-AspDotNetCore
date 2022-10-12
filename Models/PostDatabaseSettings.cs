namespace PostWebAPI.Models;

public class PostDatabaseSettings : IPostDatabaseSettings
{
    public string CollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}