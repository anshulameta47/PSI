﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweetbook.Contracts.v1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string version = "v1";
        public const string Base = Root + "/" + version;

        public static class posts
        {
            public const string GetAll = Base + "/posts";
            public const string Get = Base + "/posts/{postId}";
            public const string Create = Base + "/posts";
        }

    }
}