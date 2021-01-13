using Microsoft.AspNetCore.Mvc;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Contracts.v1;
using Tweetbook.Contracts.v1.Requests;
using Tweetbook.Contracts.v1.Responses;
using Tweetbook.Domain;
using Tweetbook.Services;

namespace Tweetbook.Controllers.v1
{
    public class PostController:Controller
    {
      
        private readonly IPostservice _postservice;
        public PostController(IPostservice postservice)
        {
            _postservice = postservice;
        }

        [HttpGet(ApiRoutes.posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return  Ok(await _postservice.GetPostsasync());
        }

        [HttpGet(ApiRoutes.posts.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid postId)
        {
            var post = await _postservice.GetPostByIdAsync(postId);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPut(ApiRoutes.posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId,[FromBody] UpdatePostRequest request)
        {
            var post = new Post
            {
                ID=postId,
                Name=request.Name
            };

            var updated =await  _postservice.UpdatePostAsync(post);
            if (!updated)
                return NotFound();

            return Ok(post);
        }

        [HttpDelete(ApiRoutes.posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        { 
            var deleted = await _postservice.DeletePostAsync(postId);
            if (deleted)
                return NoContent();

            return NotFound();
        }


        [HttpPost(ApiRoutes.posts.Create)]
        public async Task<IActionResult>  Create([FromBody] CreatePostRequest postrequest)
        {
            Post post = new Post { Name = postrequest.Name };

            
            await _postservice.CreatePostAsync(post);

            var baseurl = HttpContext.Request.Scheme+"://" +HttpContext.Request.Host.ToUriComponent();
            var locationUri = baseurl + ApiRoutes.posts.Get.Replace("{postId}", post.ID.ToString());
            var response = new PostResponse { Id = post.ID };
            return Created(locationUri,response);
        }
    }
}
