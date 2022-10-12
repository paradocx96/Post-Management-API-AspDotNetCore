using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PostWebAPI.Models;

namespace PostWebAPI.Services;

public class PostService
{
    private readonly IMongoCollection<Post> _postsCollection;

    // Database Configuration
    public PostService(
        IOptions<PostDatabaseSettings> postDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            postDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            postDatabaseSettings.Value.DatabaseName);

        _postsCollection = mongoDatabase.GetCollection<Post>(
            postDatabaseSettings.Value.CollectionName);
    }

    // Get Posts
    public async Task<List<Post>> GetAsync() =>
        await _postsCollection.Find(_ => true).ToListAsync();

    // Get Post By Id
    public async Task<Post?> GetAsync(string id) =>
        await _postsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    // Create Post
    public async Task CreateAsync(Post newPost) =>
        await _postsCollection.InsertOneAsync(newPost);

    // Update Post
    public async Task UpdateAsync(string id, Post updatePost) =>
        await _postsCollection.ReplaceOneAsync(x => x.Id == id, updatePost);

    // Delete Post
    public async Task RemoveAsync(string id) =>
        await _postsCollection.DeleteOneAsync(x => x.Id == id);
}