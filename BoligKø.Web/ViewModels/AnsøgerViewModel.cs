using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoligKø.Web.ViewModels
{
    public class AnsøgerViewModel
    {
        // ==== [UserId - LogIn] =============================================     
        [Required(ErrorMessage ="UserId - Empty")]
        public string Id { get; set; }


        // ==== [Fornavn] ====================================================  
        [Required(ErrorMessage = "Fornavn - kan ikke være tom")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Fornavn - Kun bostaver er tilladt")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Fornavn - Minimum 2 bogstaver og Max 25")]
        public string Fornavn { get; set; }


        // ==== [Efternavn] ===================================================   
        [Required(ErrorMessage = "Efternavn - kan ikke være tom")]       
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Efternavn - Kun bostaver er tilladt")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Efternavn - Minimum 2 bogstaver og Max 25")]
        public string Efternavn { get; set; }



        // ==== [Email] =======================================================  
        [Required(ErrorMessage = "Email - kan ikke være tom")]   
        //[RegularExpression(@"^[a-z0-9]+(\.[a-z0-9]+)?@+[a-z0-9]+\.[a-z0-9]{2,8}$", ErrorMessage = "Ugyldig Email")]  // Custom Email Validation
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Ugyldig Email")]  // Custom Email Validation
        public string Email { get; set; }


        // ==== [Tlf] ==========================================================  
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Tlf - Min 8 tal")]  
        [Required(ErrorMessage = "Tlf - kan ikke være tom")]
        public long Tlf { get; set; }


    }
}
