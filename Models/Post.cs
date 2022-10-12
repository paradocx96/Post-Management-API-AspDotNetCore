using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PostWebAPI.Models;

public class Post
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")] 
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime CreateDateTime = DateTime.Now;
}