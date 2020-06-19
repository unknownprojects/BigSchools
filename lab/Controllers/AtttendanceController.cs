using lab.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace lab.Controllers
{
    [Authorize]
    public class AtttendanceController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        // GET: BigSchool
        public AtttendanceController()
        {
            _dbContext = new ApplicationDbContext();
        }
        
     
    }
}
