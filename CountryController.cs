using CRUDMVCCLASS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace CRUDMVCCLASS.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Indexc()
        {
            COUNTRYMODEL model = new COUNTRYMODEL();
            DataTable dt = model.GetAllCountry();
            return View(dt);
        }
        public ActionResult Createc()
        {
            return View("Createc");
        }
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                COUNTRYMODEL model = new COUNTRYMODEL();
                string name = frm["cname"];
                bool isactive = frm["isactive"] == "on" ? true : false;

                var status = model.Insertcountry(name,isactive);
                return RedirectToAction("Indexc");
            }
            else
            {
                return RedirectToAction("Indexc");
            }
        }
        public ActionResult Editc(int countryId)
        {
            COUNTRYMODEL model = new COUNTRYMODEL();
            DataTable dt = model.GetCountryByID(countryId);
            return View(dt);
        }
        public ActionResult UpdateRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                COUNTRYMODEL model = new COUNTRYMODEL();

                string name = frm["cname"];
                bool isactive = frm["isactive"] == "on" ? true : false;
                int cid = Convert.ToInt32(frm["cid"]);
                var status = model.Updatecountry(cid,name,isactive);
                return RedirectToAction("Indexc");
            }
            else
            {
                return RedirectToAction("Indexc");
            }
        }
        public ActionResult Delete(int countryId)
        {
            COUNTRYMODEL model = new COUNTRYMODEL();
            model.Deletecountry(countryId);
            return RedirectToAction("Indexc");
        }
    }

}