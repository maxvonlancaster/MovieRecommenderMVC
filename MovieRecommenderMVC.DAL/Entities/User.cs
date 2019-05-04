using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.Entities
{
    public class User : IdentityUser<string>
    {
        public int UserId { get; set; }

        public string UserFirstName { get; set; }

        public string Password { get; set; }
    }
}
