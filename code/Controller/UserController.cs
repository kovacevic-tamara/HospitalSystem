/***********************************************************************
 * Module:  UserService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Users;
using System;

namespace Controller
{
    public class UserController : IUserController
    {

        //private Service.IService _service;
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
           this._userService = userService;
        }

        public User Save(User entity)
        {
            return _userService.Save(entity);
        }

        public bool BlockUser(string username)
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public User Login(string username, string password)
        {
            return _userService.Login(username, password);
        }

        public bool Logout(User user)
        {
            throw new NotImplementedException();
        }

 

        public Feedback SendFeedback(string feedback)
        {
            throw new NotImplementedException();
        }
    }
}