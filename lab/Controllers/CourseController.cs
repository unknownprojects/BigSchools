using lab.Models;
using lab.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace lab.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        // GET: BigSchool
        public CourseController()
        {
            _dbContext = new ApplicationDbContext();
        }
        
        [Authorize]
        public ActionResult Create()
        {

            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);


        }
        public ActionResult Home()
        {
            var upcomming = _dbContext.Courses
                .Include(c => c.Lecture)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);

            return View(upcomming);
        }
        [HttpPost]
        [Authorize]
        
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
           
            var course = new Course
            {
                CategoryId = viewModel.Category,
                DateTime = viewModel.GetDateTime(),
                LectureId = User.Identity.GetUserId(),
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}