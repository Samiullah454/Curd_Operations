using Curd_Operations.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Curd_Operations.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        CrudDbEntities dbObj= new CrudDbEntities();
        public ActionResult Student( Student_Details obj)

        {
            if(obj != null)
            
                return View(obj);
            
             else 
                return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student_Details model)
        {
            if(ModelState.IsValid)
            {
                Student_Details obj = new Student_Details();
                obj.Std_ID = model.Std_ID;
                obj.Std_FName = model.Std_FName;
                obj.Std_LName = model.Std_LName;
                obj.Std_Cnic = model.Std_Cnic;
                obj.Std_Dob = model.Std_Dob;
                obj.Std_Email = model.Std_Email;
                obj.Std_PhoneNo = model.Std_PhoneNo;
                obj.Std_Gender = model.Std_Gender;
                obj.Std_Address = model.Std_Address;
                obj.Std_Grade = model.Std_Grade;
                if (model.Std_ID == 0)
                {
                    dbObj.Student_Details.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }
                
            }
            ModelState.Clear();
            return View("Student");
        }
        public ActionResult StudentList()
        {
            var res = dbObj.Student_Details.ToList();
            return View(res);
        }
   
        public ActionResult Delete(int? id)
        {
            var res = dbObj.Student_Details.Where(x => x.Std_ID == id).First();
            dbObj.Student_Details.Remove(res);
            dbObj.SaveChanges();
            var list = dbObj.Student_Details.ToList();
            return View("StudentList", list);
        }


    }
}