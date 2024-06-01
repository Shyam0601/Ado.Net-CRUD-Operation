using CRUDMVCCLASS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CRUDMVCCLASS.Controllers
{
    public class CrudController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDMODEL model = new CRUDMODEL();
            DataTable dt = model.GetAllStudents();
            return View(dt);

        }


        public ActionResult Create()
        {
            CRUDMODEL model = new CRUDMODEL();
            var getCountry = model.CountryList();
            ViewBag.countryList = new SelectList("dtbl", "countryId", "countryName");
            return View();
        }
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDMODEL model = new CRUDMODEL();
                string name = frm["sname"];
                string address = frm["address"]; 
                int age = Convert.ToInt32(frm["age"]);
                int countryList = Convert.ToInt32(frm["countryList"]);
                bool isactive = frm["isactive"] == "on" ? true : false;

                var status = model.Insertstudent(name, address, age, countryList, isactive);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public ActionResult Edit(int StudentID)
        {
            CRUDMODEL model = new CRUDMODEL();
          

            DataTable dt = model.GetstudentByID(StudentID);
            int pro = dt.Rows[0].Field<int>(4);
            var getCountry = model.CountryList();
            ViewBag.countryList = new SelectList(getCountry, "countryId", "countryName", pro);
            return View(dt);
        }

        public ActionResult UpdateRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDMODEL model = new CRUDMODEL();
              
                string name = frm["sname"];
                int age = Convert.ToInt32(frm["age"]);
                string address = frm["address"];
                bool isactive = frm["isactive"] == "on" ? true : false;
                int sid = Convert.ToInt32(frm["sid"]);
                int countryList = Convert.ToInt32(frm["countryList"]);
                int status = model.Updatestudent(sid, name, address, age, countryList, isactive);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int StudentId)
        {
            CRUDMODEL model = new CRUDMODEL();
            model.Deletestudent(StudentId);
            return RedirectToAction("Index");
        }

    }

}

