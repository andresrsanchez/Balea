﻿using System.Diagnostics;
using System.Threading.Tasks;
using ContosoUniversity.EntityFrameworkCore.Store.Infrastructure;
using ContosoUniversity.EntityFrameworkCore.Store.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Configuration.Store.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Teachers()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [AuthorizeRoles(nameof(Roles.Teacher), nameof(Roles.Student))]
        public IActionResult Courses()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Tokens()
        {
            var tokens = new Tokens
            {
                AccessToken = await HttpContext.GetTokenAsync("access_token"),
                IdToken = await HttpContext.GetTokenAsync("id_token")
            };

            return View(tokens);
        }
    }
}
