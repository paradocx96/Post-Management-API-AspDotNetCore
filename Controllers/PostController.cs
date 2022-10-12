using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostWebAPI.Models;
using PostWebAPI.Services;

namespace PostWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService) =>
            _postService = postService;

        // Create Post
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            await _postService.CreateAsync(post);

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        // Get All Posts
        [HttpGet]
        public async Task<List<Post>> GetPost() =>
            await _postService.GetAsync();

        // Get Post By Id
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Post>> GetPostById(string id)
        {
            var post = await _postService.GetAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            return post;
        }

        // Update Post
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdatePost(string id, Post updatedPost)
        {
            var post = await _postService.GetAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            updatedPost.Id = post.Id;

            await _postService.UpdateAsync(id, updatedPost);

            return NoContent();
        }

        // Delete Post
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            var post = await _postService.GetAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            await _postService.RemoveAsync(id);

            return NoContent();
        }
    }
}