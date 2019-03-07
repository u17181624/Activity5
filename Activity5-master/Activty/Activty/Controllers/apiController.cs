using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Activty.Models;
using System.Dynamic;

namespace Activty.Controllers
{
    public class apiController : ApiController
    {
        Activity5Entities db = new Activity5Entities();
        //Customer Api
        [System.Web.Http.Route("api/api/GetCustomer")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> GetCustomer()
        {
           List<Customer> cuslist = db.Customers.ToList();
            return getCust(cuslist);
        }
        [System.Web.Http.Route("api/api/addEmployee")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> addCustomer([FromBody] Customer customer)
        {

            db.Customers.Add(customer);
            db.SaveChanges();
            List<Customer> cuslist = db.Customers.ToList();
            return getCust(cuslist);
        }
        //Employee Api
        [System.Web.Http.Route("api/api/GetEmployee")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> GetEmployee()
        {
            List<Employee> emplist = db.Employees.ToList();
            return getEmp(emplist);
        }
        [System.Web.Http.Route("api/api/addEmployee")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> addEmployee([FromBody] Employee employee)
        {
            
            db.Employees.Add(employee);
            db.SaveChanges();
            List<Employee> emplist = db.Employees.ToList();
            return getEmp(emplist);
        }
        //Sales APi
        [System.Web.Http.Route("api/api/GetSales")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> GetSales()
        {
            List<Sale> sallist = db.Sales.ToList();
            return getSal(sallist);
        }
        /**
         this is where all my methods begin
            **/
        public List<dynamic> getCust(List<Customer> customer)
        {
            List<dynamic> cuslist = new List<dynamic>();
            foreach (Customer cus in customer)
            {
                dynamic dyncustomer = new ExpandoObject();
                dyncustomer.ID = cus.CusID;
                dyncustomer.name = cus.name;
                dyncustomer.surname = cus.surname;
                cuslist.Add(dyncustomer);

            }

            return cuslist;
        }
        public List<dynamic> getEmp(List<Employee> employee)
        {
            List<dynamic> cuslist = new List<dynamic>();
            foreach (Employee emp in employee)
            {
                dynamic dynemployee = new ExpandoObject();
                dynemployee.ID = emp.empID;
                dynemployee.name = emp.name;
                cuslist.Add(dynemployee);

            }

            return cuslist;
        }
        public List<dynamic> getSal(List<Sale> sales)
        {
            List<dynamic> sallist = new List<dynamic>();
            foreach (Sale sal in sales)
            {
                dynamic dynsale = new ExpandoObject();
                dynsale.ID = sal.SaleID;
                dynsale.cust = sal.CusID.Value;
                dynsale.surname = sal.empID.Value;
                sallist.Add(dynsale);

            }

            return sallist;
        }


    }
}