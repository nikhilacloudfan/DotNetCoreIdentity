using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Manager.Interface;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ICharacterManager _characterManager;
        private readonly IMapper _mapper;
        public UserProfileController(UserManager<ApplicationUser> userManager, IMapper mapper, ICharacterManager characterManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _characterManager = characterManager;
        }
        [HttpGet]
        [Authorize]
        //GET: /api/UserProfile
        public async Task<object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName,
                user.MaxCharacterCount
            };
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        //GET: /api/UserProfile/ForAdmin
        public string GetForAdmin()
        {
            return "Web method for admin";
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetAllusers")]
        //GET: /api/UserProfile/GetAllusers
        public async Task<object> GetAllusers()
        {
            var usersList = new List<ApplicationUserModel>();
            var users = await _userManager.GetUsersInRoleAsync("Customer");
            usersList.AddRange(users.Select(m => MapToApplicationUserModel(m)));
            return usersList;
        }

        private ApplicationUserModel MapToApplicationUserModel(ApplicationUser user)
        {
            var userId = user.Id;
            var characters = _characterManager.GetAllUserCharacters(userId);
            return new ApplicationUserModel()
            {
                Email = user.Email,
                FullName = user.FullName,
                UserName = user.UserName,
                Characters = characters
            };
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("ForCustomer")]
        //GET: /api/UserProfile/GetForCustomer
        public string GetForCustomer()
        {
            return "Web method for customer";
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        [Route("ForAdminOrCustomer")]
        //GET: /api/UserProfile/ForAdminOrCustomer
        public string GetForAdminOrCustomer()
        {
            return "Web method for admin or customer";
        }

    }
};