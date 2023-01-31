﻿using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        public HttpResponse All()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            return this.View();
        }

        public HttpResponse Create()
        {
            return this.View();
        }
    }
}
