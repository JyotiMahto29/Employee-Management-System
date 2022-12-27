using demo.Models;
using demo.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Controllers
{
    [NoDirectAccess]
    public class employeeMasterController : Controller
    {
        
        employeeMasterRepository _employeeRepository = new employeeMasterRepository();
        deptRepository _deptMaster = new deptRepository();

        // GET: employeeMaster
        public ActionResult Index()
        {

            ModelState.Clear();
            var result = _employeeRepository.GetAllData();
            return View(result);

        }
        // GET: employeeMaster/Add    
        public ActionResult Add()
        {
            var result = _deptMaster.GetAllData();
            employeeMaster emp = new employeeMaster(); 
            emp.ddldepartment = new SelectList(result, "deptId", "deptName"); // model binding 
           
            return View("Add", emp);
        }

        // POST: employeeMaster/Add    
        [HttpPost]
        public ActionResult Add(employeeMaster employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_employeeRepository.InsertData(employee))
                    {
                        ViewBag.Message = "Employee details added successfully!!";
                    }
                    else
                    {
                        ViewBag.Message = "Employee details already exists!";
                    }
                }

                var result = _deptMaster.GetAllData();
                employeeMaster emp = new employeeMaster();
                emp.ddldepartment = new SelectList(result, "deptId", "deptName"); // model binding 

                return View("Add", emp);
            }
            catch
            {
                return View();
            }
        }

        // GET: employeeMaster/Edit/5     
        public ActionResult Edit(int id)
        {
            var result = _deptMaster.GetAllData();
            var result1 = _employeeRepository.GetAllData().Find(employee => employee.EmployeeId == id);
            employeeMaster emp = new employeeMaster();
            emp.EmployeeId = result1.EmployeeId;
            emp.EmployeeName=result1.EmployeeName;
            emp.Address = result1.Address;
            emp.Position=result1.Position;
            emp.Contact = result1.Contact;
            emp.EmailId = result1.EmailId;
            emp.Salary=result1.Salary;
            emp.deptId = result1.deptId;
            emp.ddldepartment = new SelectList(result, "deptId", "deptName"); 
            return View("Edit",emp);



        }
        // POST: employeeMaster/Edit/5    
        [HttpPost]

        public ActionResult Edit(int id, employeeMaster model)
        {
            try
            {
                _employeeRepository.UpdateData(model);

                return RedirectToAction("Index");
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

                if (_employeeRepository.DeleteData(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";



                }
                return RedirectToAction("Index");



            }
            catch
            {
                return View();
            }
        }
    }
}