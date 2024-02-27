using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApplicationNew.Models;

namespace MVCApplicationNew.Controllers
{
    public class ProjectController : Controller
    {
        public static List<Project> projectList = new List<Project>();
        public IActionResult Index()
        {
            return View(projectList);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(Project project)
        {
            // Check if the primary key is unique
            //if (!IsPrimaryKeyUnique(project.ProjectId))
            //{
            //    ModelState.AddModelError("ProjectId", "Project ID must be unique.");
            //    return View("Create");
            //}

            // Check project end date is greater than project start date
            if (!IsDateValide(project.StartDate, project.EndDate))
            {
                ModelState.AddModelError("EndDate", "EndDate must be greater than StartDate");
                return View("Create");
            }
            if (ModelState.IsValid)
            {
                Project item = projectList.Find(p => p.ProjectId == project.ProjectId);
                int index = projectList.IndexOf(item);
                if (index >= 0)
                {
                    projectList[index] = project;
                }
                else
                {
                    projectList.Add(project);
                }
                
                return RedirectToAction("Index");

            }
            return View("Create",project);

        }

        //ProjectId Validation
        public static bool IsPrimaryKeyUnique(int projectId)
        {
            // Check if any project with the given ID exists in the list
            bool ans = true;
            for (int i = 0; i < projectList.Count; i++)
            {
                if (projectList[i].ProjectId == projectId)
                {
                    ans = false;
                    break;
                }
            }
            return ans;
        }

        //Project Date Validation
        public bool IsDateValide(DateTime StartDate, DateTime EndDate)
        {
            bool ans = true;
            if (StartDate >= EndDate)
            {
                ans = false;
            }
            return ans;
        }

        public IActionResult Edit(int id)
        {
            Project project = projectList.Find(p => p.ProjectId == id);
            return View(project);
        }

        public IActionResult Delete(int id)
        {
            for (int i = 0; i < projectList.Count; i++)
            {
                if (projectList[i].ProjectId == id)
                {
                    projectList.Remove(projectList[i]);
                }
            }
            return RedirectToAction("Index");
        }
    }
}