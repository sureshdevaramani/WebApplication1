﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAcessLayer1;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        public Class1 customer = new Class1();
      
        [HttpGet]
        // GET: Customer
        public ActionResult Index()
        {
            
            DataSet dataSetState = customer.GetStates();

            ViewBag.statename = dataSetState.Tables[0];
            List<SelectListItem> getstatename = new List<SelectListItem>();


            foreach (System.Data.DataRow dr in ViewBag.statename.Rows)
            {
                getstatename.Add(new SelectListItem {
                    Text = @dr["state_name"].ToString(),
                    Value = @dr["state_id"].ToString() });

                ViewBag.state = getstatename;
            }

            DataSet genderdataset = customer.GetGender();
            ViewBag.gendername = genderdataset.Tables[0];
            List<SelectListItem> getgendername = new List<SelectListItem>();

            foreach (System.Data.DataRow dr in ViewBag.gendername.Rows)
            {
                getgendername.Add(new SelectListItem { 
                    Text = @dr["gender_"].ToString(), 
                    Value = @dr["gender_id"].ToString() });

                ViewBag.gender_ = getgendername;
            }



            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formdata)
        {
            string NRI_DATA = formdata["nri_flag"].ToString();
            string Tobacco = formdata["tobbaco_user_flag"].ToString();

            if (NRI_DATA == "true,false")
            {
                NRI_DATA = "1";
                Response.Write("NRI = " + NRI_DATA);

            }
            else if(NRI_DATA == "false")
            {
                NRI_DATA = "0";
            }

            if (Tobacco == "true,false")
            {
                Tobacco = "1";
                Response.Write("NRI = " + Tobacco);

            }
            else if (Tobacco == "false")
            {
                Tobacco = "0";
            }


            customer.AddCustomer(formdata["first_name"],
                formdata["last_name"],
                Convert.ToInt32(formdata["gender_"]),
                Convert.ToDateTime(formdata["date_of_birth"]),
                NRI_DATA,
                Tobacco, 
                formdata["Email_id"].ToString(),
                formdata["Address_Line1"].ToString(), 
                formdata["Address_Line2"].ToString(), 
                Convert.ToInt32(formdata["state"]),
                Convert.ToInt64(formdata["Phone_Number"]));


           
            TempData["Phone_Number"] = Convert.ToInt64(formdata["Phone_Number"]);


            return RedirectToAction("Index", "Policy");

            }
        }


    }


