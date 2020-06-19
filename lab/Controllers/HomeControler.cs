using lab.Models;
using lab.ViewModel;
using lab.Controllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace lab.Controllers
{
    public class HomeControler : Controller
    {
        private ApplicationDbContext _dbContext;
    }

}