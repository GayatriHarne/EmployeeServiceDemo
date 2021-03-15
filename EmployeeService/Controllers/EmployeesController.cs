using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;
using System.Data.SqlClient;
using System.Web.Http.Cors;
using System.Threading;

namespace EmployeeService.Controllers
{

    [BasicAuthorization]
    public class EmployeesController : ApiController
    {
        /// <summary>
        /// Get list of employees corresponding to specified Gender(Password)
        /// </summary>
        /// <param name="Gender"></param>
        /// <returns>Status code with employee data </returns>
        //GET  api/Employees
        [HttpGet]
        public HttpResponseMessage GetEmployees()
        {
           string Gender = Thread.CurrentPrincipal.Identity.Name;
            
            using (GHEntities entities = new GHEntities())
            {
                switch (Gender.ToLower())
                {
                    
                    case "male":
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e=>e.Gender.ToLower()=="male").ToList());
                        }
                    case "female":
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                        }
                    default:
                        return Request.CreateResponse(HttpStatusCode.Unauthorized) ;

                }
            }
        }
        //Get data for employee with provided id 
        //GET api/Employees/{id}
        [HttpGet]
        public HttpResponseMessage GetEmployeeById(int Id)
        {
            using (GHEntities entities = new GHEntities())
            {
                var entity= entities.Employees.FirstOrDefault(e => e.Id == Id);
                if (entity != null)
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                else
                    return Request.CreateResponse (HttpStatusCode.BadRequest, "Employee with Id=" + Id + " not found");
            }
        }
        //Add Emloyees data to the table
        //POST api/Employees
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            using(GHEntities entities=new GHEntities())
            {
                try {
                    entities.Employees.Add(employee);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri +"/"+ employee.Id.ToString());
                    return message;
                }
                catch(Exception ex)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
 
                }
              
            }

        }

        //Delete specified employee information from table
        //DELETE api/Employees/{id}
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (GHEntities entities = new GHEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.Id == id);
                    if (entity == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Id with value =" + id + " not found");

                    }
                    else
                    {
                        entities.Employees.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);

                    }

                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        //Update employee information in the table
        //PUT api/Employees/{id} 
        public HttpResponseMessage Put([FromUri] Employee employee,[FromBody]int Id)
        {
            try
            {
                using (GHEntities entities = new GHEntities())
                {
                    var emp = entities.Employees.FirstOrDefault(e => e.Id == Id);
                    if (emp != null)
                    {
                        emp.FirstName = employee.FirstName;
                        emp.Gender = employee.Gender;
                        emp.LastName = employee.LastName;
                        emp.Salary = employee.Salary;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, emp);

                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Id =" + Id + " not found");
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
         

            
        }

    }
}
