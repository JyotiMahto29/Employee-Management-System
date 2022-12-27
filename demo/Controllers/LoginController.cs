using demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using  demo.Models;
using demo.Common;

namespace demo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        userMasterRepository _userMaster = new userMasterRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();

        }
        public ActionResult Logout()
        {
            Session["userID"] = "";
            Session["userName"] = "";
            Session.Abandon();
            return RedirectToAction("Login","Login");

        }
        [HttpPost]
        public ActionResult Login(userLogin log)
        {
            userMaster userlog = new userMaster();
            try
            {
                if (ModelState.IsValid)
                {
                    Password decrypt = new Password();

                    userlog = _userMaster.Authentication(log);



                    if (userlog != null)
                    {

                        Session["userID"] = userlog.userId.ToString();
                        Session["userName"] = userlog.userName.ToString();
                        return RedirectToAction("Index", "employeeMaster");

                    }
                    else
                    {
                        ViewBag.Message = "Invalid credentials!";
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