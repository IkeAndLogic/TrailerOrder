using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class AddEmployeeViewModel
    {
        [Required(ErrorMessage = "You must provide the First Name"),MinLength(1), MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "You must provide the Middle Name"), MinLength(1), MaxLength(50)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "You must provide the Last Name"), MinLength(1), MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "You must provide the Street Number"), MinLength(1), MaxLength(10)]
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }


        [Required(ErrorMessage = "You must provide the Street Name"), MinLength(1), MaxLength(50)]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "You must provide the City Name"), MinLength(1), MaxLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }


        [Required(ErrorMessage = "You must provide the Zip Code"),MinLength(5), MaxLength(11)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }



        [Required(ErrorMessage = "You must provide the Social Security Number")]
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }

        [Required(ErrorMessage = "You must Confirm the Social Security Number")]
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        [Compare("SSN", ErrorMessage ="Passwords do not match")]
        [Display(Name = "Social Security Number")]
        public string SsnConfirm { get; set; }

        [Required(ErrorMessage = "You must provide the Date of Birth"), DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "You must provide the License Number")]
        [Display(Name = "License Number")]
        public string LicNumber { get; set; }

        [Required(ErrorMessage = "You must provide the License Issuance Date"), DataType(DataType.Date)]
        [Display(Name = "License Issuance Date")]
        public DateTime LicIssue { get; set; }

        [Required(ErrorMessage = "You must provide the License Exipration Date"), DataType(DataType.Date)]
        [Display(Name = "License Expiration Date")]
        public DateTime LicExpire { get; set; }

        [Required(ErrorMessage = "You must provide the Medical Card Number")]
        [Display(Name = "Medical Card Number")]
        public string MedCardNumber { get; set; }

        [Required(ErrorMessage = "You must provide the Medical Card Issuance Date"), DataType(DataType.Date)]
        [Display(Name = "Medical Card Issuance Date")]
        public DateTime MedIssue { get; set; }

        [Required(ErrorMessage = "You must provide the Medical Card Exipration Date"), DataType(DataType.Date)]
        [Display(Name = "Medical Card Expiration Date")]
        public DateTime MedExpire { get; set; }

        [Required(ErrorMessage = "You must provide the User Name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    
        [Required(ErrorMessage = "You must provide a Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must provide Confirm the Password")]
        [Display(Name = "Password")]
        public string PasswordConf { get; set; }



        [Required(ErrorMessage = "You must provide the Job Title")]
        [Display(Name = "Title")]
        public EmployeeType Title { get; set; }

        public List<SelectListItem> EmployeeTitles { get; set; }



        public AddEmployeeViewModel()
        {
            EmployeeTitles = new List<SelectListItem>();

            EmployeeTitles.Add(new SelectListItem
            {
                Value = ((int)EmployeeType.Dispatcher).ToString(),
                Text = EmployeeType.Dispatcher.ToString()
            });


            EmployeeTitles.Add(new SelectListItem
            {
                Value = ((int)EmployeeType.Driver).ToString(),
                Text = EmployeeType.Driver.ToString()
            });

            EmployeeTitles.Add(new SelectListItem
            {
                Value = ((int)EmployeeType.Mechanic).ToString(),
                Text = EmployeeType.Mechanic.ToString()
            });

            EmployeeTitles.Add(new SelectListItem
            {
                Value = ((int)EmployeeType.Recruiter).ToString(),
                Text = EmployeeType.Recruiter.ToString()
            });

            EmployeeTitles.Add(new SelectListItem
            {
                Value = ((int)EmployeeType.MechanicManger).ToString(),
                Text = EmployeeType.MechanicManger.ToString()
            });


        }


    }
}
