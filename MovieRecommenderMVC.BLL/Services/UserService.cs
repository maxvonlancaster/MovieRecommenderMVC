using MovieRecommenderMVC.BLL.Services.Interfaces;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
