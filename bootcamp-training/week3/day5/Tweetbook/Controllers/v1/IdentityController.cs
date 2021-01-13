using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Contracts;
using Tweetbook.Contracts.v1;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Services;


namespace Tweetbook.Controllers.V1
    {
        public class IdentityController : Controller
        {
            private readonly IIdentityService _identityService;

            public IdentityController(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            [HttpPost(ApiRoutes.Identity.Login)]
            public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
            {
                var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

                if (!authResponse.Success)
                {
                    return BadRequest(new AuthFailedResponse
                    {
                        Errors = authResponse.Errors
                    });
                }

                return Ok(new AuthSuccessResponse
                {
                    Token = authResponse.Token,
                    RefreshToken = authResponse.RefreshToken
                });

            }
