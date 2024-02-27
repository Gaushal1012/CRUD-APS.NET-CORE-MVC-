using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApplicationNew.Models;

namespace MVCApplicationNew.Controllers
{
    public class ProjectAJAXController : Controller
    {
        public static List<Project> projectList = new List<Project>();
        public IActionResult Index()
        {
            return View(projectList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}