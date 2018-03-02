using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    //public class Customer
    //{
    //    public string CustomerName { get; set; }
    //    public string Address { get; set; }
    //    //当返回类型如“Customer”这样类似的对象时，将调用ToString()方法，返回“NameSpace.ClassName”形式的类名。
    //    public override string ToString()
    //    {
    //        return this.CustomerName + "|" + this.Address;
    //    }
    //}
    public class EmployeeController : Controller
    {
        //Test/GetString
        public string GetString()
        {
            return "<!DOCTYPE html><html lang=\"zh-cn\"><head><meta charset=\"utf-8\"/>" +
        "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />" +
        "<title>ASP.NET Core 快速入门（实战篇） - 农码一生 - 博客园</title>" +
        "</head>" +
        "<body>" +
        "<a href=\"http://www.baidu.com\" name=\"top\">Hello World is old now. It’s time for wassup bro</a>";
        }
        //Test/String
        public string String(string www)
        {
            return "<!DOCTYPE html><html lang=\"zh-cn\"><head><meta charset=\"utf-8\"/>" +
                    "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />" +
                    "<title>ASP.NET Core 快速入门（实战篇） - 农码一生 - 博客园</title>" +
                    "</head>" +
                    "<body>" +
"<a href=\"" + www + "\" name=\"top\">Hello World is old now. It’s time for wassup bro</a>";
        }
        //Test/GetCustomer
        //public Customer GetCustomer()
        //{
        //    Customer c = new Customer();
        //    c.CustomerName = "郭老板";
        //    c.Address = "株洲市";
        //    return c;
        //}
        [NonAction]  //  /Test/SimpleMethod
        public string SimpleMethod()
        {
            return "Hi, I am not action method";
        }
        [Authorize]
        public ActionResult Index(string str) 
        {
            //if (string.IsNullOrEmpty(str))
            //{
            //    Employee emp = new Employee();
            //    emp.FirstName = "Sukesh";
            //    emp.LastName = "Marla";
            //    emp.Salary = 20000;
            //    //ViewData["Employee"] = emp;
            //    //ViewBag.Employee = emp;
            //    //return View("MyView", emp);

            //    EmployeeViewModel vmEmp = new EmployeeViewModel();
            //    vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            //    vmEmp.Salary = emp.Salary.ToString("C");
            //    if (emp.Salary > 15000) 
            //    { vmEmp.SalaryColor = "yellow"; } 
            //    else 
            //    {
            //        vmEmp.SalaryColor = "green";
            //    }
            //    vmEmp.UserName = "Admin";
            //    return View("MyView",vmEmp);
            //}
            //else 
            //{
            //    return View("YourView");
            //}

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.UserName = User.Identity.Name;
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();
            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();
            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString();
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else 
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            //employeeListViewModel.UserName = "Admin";
            return View("Index", employeeListViewModel);
        }
        public ActionResult AddNew() 
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit) 
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else 
                    {
                        //return View("CreateEmployee");
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary.HasValue)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else 
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", vm);
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
            
        }
    }
}