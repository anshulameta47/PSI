using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Contracts.v1;
using Tweetbook.Contracts.v1.Requests;
using Tweetbook.Contracts.v1.Responses;
using Tweetbook.Domain;

namespace Tweetbook.Controllers.v1
{
    public class PostController:Controller
    {
        public List<Post> _posts;
        public PostController()
        {
            _posts = new List<Post>();
            for(int i=0;i<5;i++)
            {
                _posts.Add(new Post { ID = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRoutes.posts.GetAll)]
        public IActionResult GetAll() => Ok(_posts);
        [HttpPost(ApiRoutes.posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postrequest)
        {
            var post = new Post { ID = postrequest.Id };

            if(string.IsNullOrEmpty(post.ID))
            {
                post.ID = Guid.NewGuid().ToString();
            }
            _posts.Add(post);
            var baseurl = HttpContext.Request.Scheme+"://" +HttpContext.Request.Host.ToUriComponent();
            var locationUri = baseurl + ApiRoutes.posts.Get.Replace("{postId}", post.ID);
            var response = new PostResponse { Id = postrequest.Id };
            return Created(locationUri,response);
        }
    }
}
