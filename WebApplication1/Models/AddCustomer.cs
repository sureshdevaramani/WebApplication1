﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class AddCustomer 
    {
        [Display(Name = "First Name")]
        [Required]
        public string first_name { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string last_name { get; set; }

        public int gender_code { get; set; }

        [Display(Name = "Select Gender")]
        [Required(ErrorMessage ="Required")]

        public int gender_ { get; set; }

        [Display(Name = "Date of Birth")]

        public string date_of_birth { get; set; }

        [Display(Name = "Is NRI?")]

        public bool nri_flag { get; set; }

        [Display(Name = "Is Tobacco user?")]

        public bool tobbaco_user_flag { get; set; }

        [Display(Name = "Address Line 1")]

        public string Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]

        public string Address_Line2 { get; set; }

        [Required]
        public IEnumerableList<SelectListItem> State { get; set; }


        public string City { get; set; }

        [Display(Name = "Email ID")]

        public string Email_Id { get; set; }

        [Display(Name = "Nominee Name")]

        public string Nominee_name { get; set; }

        [Display(Name = "Phone Number")]
        public long  Phone_Number { get; set; }

    }
}