using demo.Models;
using demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Controllers
{
    public class userMasterController : Controller
    {
        userMasterRepository _userRepository = new userMasterRepository();
        // GET: userMaster
        public ActionResult Index()
        {
            return View();
        }
        // GET: userMaster/Add    
        public ActionResult Add()
        {
            return View();
        }

        // POST: userMaster/Add    
        [HttpPost]
        public ActionResult Add(userMaster user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_userRepository.InsertData(user))
                    {
                        ViewBag.Message = "User details added successfully";
                    }
                    else
                    {
                        ViewBag.Message = "User details already exists!";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

    }
}