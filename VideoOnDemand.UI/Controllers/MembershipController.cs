using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoOnDemand.Data.Data.Entities;
using VideoOnDemand.UI.Models.DTOModels;
using VideoOnDemand.UI.Repositories;

namespace VideoOnDemand.UI.Controllers
{
    public class MembershipController : Controller
    {

        private string _userId;
        private IMapper _mapper;
        private IReadRepository _db;

        public MembershipController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IMapper mapper, IReadRepository db)
        {
            var user = httpContextAccessor.HttpContext.User;
            _userId = userManager.GetUserId(user);
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Course(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Video(int id)
        {
            return View();
        }

    }
}