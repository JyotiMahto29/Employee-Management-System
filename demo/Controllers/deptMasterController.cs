using demo.Models;
using demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Controllers
{
    [NoDirectAccess]
    public class deptMasterController : Controller
    {
        deptRepository _deptRepository = new deptRepository();
        // GET: deptMaster
        public ActionResult Index()
        {
            
            ModelState.Clear();
            var result = _deptRepository.GetAllData();
            return View(result);

        }
        // GET: deptMaster/Add    
        public ActionResult Add()
        {
            return View();
        }



        // POST: deptMaster/Add    
        [HttpPost]
        public ActionResult Add(deptMaster dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_deptRepository.InsertData(dept))
                    {
                        ViewBag.Message = "Department details added successfully";
                    }
                    else
                    {
                        ViewBag.AlertMsg = "Department details already exists!";
                    }
                }



                return View();
            }
            catch
            {
                return View();
            }
        }



        // GET: deptMaster/Edit/5     
        public ActionResult Edit(int id)
        {
            return View(_deptRepository.GetAllData().Find(dept => dept.deptId == id));



        }



        // POST: deptMaster/Edit/5    
        [HttpPost]



        public ActionResult Edit(int id, deptMaster model)
        {
            try
            {
                _deptRepository.UpdateData(model);

                if (_deptRepository.UpdateData(model))
                {
                    ViewBag.Message = "Department details Updated successfully";

                }
                else
                {
                    ViewBag.AlertMsg = "Department Name already exists!";
                   

                }

                return View();
            }
            catch
            {
                return View();
            }
        }



        // GET: deptMaster/DeleteData/5    
        public ActionResult DeleteData(int id)
        {
            try
            {
                var result = _deptRepository.GetAllData();

                if (_deptRepository.DeleteData(id))
                {
                    ViewBag.Message = "Department details deleted successfully";
                   
                }
                else
                {
                    ViewBag.AlertMsg = "You can not delete. This department is already in use for Employee!";
                   
                }
                //return RedirectToAction("Index");
                
                return View("Index", result);

            }
            catch
            {
                return View();
            }
        }

    }
}