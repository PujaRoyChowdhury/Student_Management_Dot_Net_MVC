//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace Student_Managment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class userregistration
    {
        public int registrationid { get; set; }
        [Display(Name = "First Name")]
        public string firstname { get; set; }
        [Display(Name = "Middle Name")]
        public string middlename { get; set; }
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public System.DateTime dob { get; set; }
        [Display(Name = "LoginId")]
        public string login { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Country")]
        public Nullable<int> country { get; set; }
        [Display(Name = "State")]
        public Nullable<int> state { get; set; }
        [Display(Name = "City")]
        public Nullable<int> city { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "PhoneNo.")]
        public string phoneno { get; set; }

        public virtual city city1 { get; set; }
        public virtual country country1 { get; set; }
        public virtual state state1 { get; set; }
    }
}
