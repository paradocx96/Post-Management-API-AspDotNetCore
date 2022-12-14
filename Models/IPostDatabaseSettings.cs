namespace PostWebAPI.Models;

public interface IPostDatabaseSettings
{
    string CollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}