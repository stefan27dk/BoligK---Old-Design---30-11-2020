using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoligKø.Web.ViewModels
{
    public class AnsøgningViewModel
    {
        //public AnsøgerViewModel Ansøger { get; set; }


        // ==== [UserId - LogIn] =============================================  
        public string UserId { get; set; }



        // ==== [Post Nr] ===================================================
        [Range(0555, 9999, ErrorMessage = "Post Nr - Min / Max - 4 tal")]
        [Display(Name = "Post Nr")]
        [Required(ErrorMessage = "Post Nr - kan ikke være tom")]
        public int PostNr { get; set; }






        // ==== [Dyr] ======================================================    
        [Display(Name = "Små Dyr")]
        public bool SmåDyr { get; set; }



        [Display(Name = "Stor Dyr")]
        public bool StorDyr { get; set; }






        // ==== [Antal Værelser] ===================================================    
        [Range(1, 20, ErrorMessage = "Fra Antal Værelser - Min 1 og Max 20")]
        [Display(Name = "Fra Antal Værelser")]
        [Required(ErrorMessage = "Fra Antal Værelser - kan ikke være tom")]
        public int FraAntalVærelser { get; set; }


        [Range(1, 20, ErrorMessage = "Til Antal Værelser - Min 1 og Max 20")]
        [CompareNumbers("FraAntalVærelser", ErrorMessage = "Til Antal Værelser skal være større end Fra Antal Værelser")]
        [Display(Name = "Til Antal Værelser")]
        [Required(ErrorMessage = "Til Antal Værelser - kan ikke være tom")]
        public int TilAntalVærelser { get; set; }






        // ==== [Pris] ===================================================      
        [Range(500,20000, ErrorMessage = "Fra Pris - Min 500kr og Max 20.000kr")]
        [Display(Name = "Fra Pris")]
        [Required(ErrorMessage = "Fra Pris - kan ikke være tom")]   
        public double FraPris { get; set; }


        [Range(500,20000, ErrorMessage = "Til Pris - Min 500kr og Max 20.000kr")]
        [CompareNumbers("FraPris", ErrorMessage = "Til Pris skal være større end Fra Pris")] // On Submit Validation
        [Display(Name = "Til Pris")]
        [Required(ErrorMessage = "Til Pris - kan ikke være tom")]   
        public double TilPris { get; set; }







        // ==== [Kvadratmeter] ===================================================    
        [Range(5, 800, ErrorMessage = "Fra m2 - Min 5 m2 og Max 800 m2")]
        [Display(Name = "Fra m2")]
        [Required(ErrorMessage = "Fra m2 kan ikke være tom")]
        public double FraKvm { get; set; }


        [Range(5, 800, ErrorMessage = "Til m2 - Min 5 m2 og Max 800 m2")]
        [CompareNumbers("FraKvm", ErrorMessage = "Til m2 - skal være større end Fra m2")]
        [Display(Name = "Til m2")]
        [Required(ErrorMessage = "Til m2 - kan ikke være tom")]
        public double TilKvm { get; set; }







        // ==== [Lejemåls Type] ===================================================   
        [Display(Name ="Lejemåls Type")]
        [Required(ErrorMessage = "Lejemåls Type - kan ikke være tom")]    
        public LejemålTypeKriterie LejemålsType { get; set; }





        // ==== [Øvrige Kommentar] ===================================================  
        [MaxLength(500, ErrorMessage = "Øvrige Kommentar - kan ikke overskride 500 tegn")]
        [Display(Name = "Øvrige Kommentar")]
        [Required(ErrorMessage = "Øvrige Kommentar - kan ikke være tom")]
        public string ØvrigeKommentar { get; set; }
        //public IEnumerable<IKriterie> Kriterier { get; private set; }











        // ==========================# Custome Anotation Validation - || Class || #=========================================================
        public class CompareNumbers : ValidationAttribute
        {
            private readonly string _comparisonProperty;



            // || Constructor ||
            public CompareNumbers(string comparisonProperty)
            {
                _comparisonProperty = comparisonProperty;
            }




            // Validation - || Mehtod ||
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                ErrorMessage = ErrorMessageString;
                // Remote Value
                var currentValue = Convert.ToDouble(value);
                
                // Get the prop for Comparison
                var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
                if(property == null)
                {
                    throw new ArgumentException("Property with this name not found");
                }

                // Get the Value for Comparison
                var comperisonValue = Convert.ToDouble(property.GetValue(validationContext.ObjectInstance));

                // Compare
                if(currentValue < comperisonValue)
                {
                    return new ValidationResult(ErrorMessage);
                }   

                return ValidationResult.Success;
                //return base.IsValid(value, validationContext);
            }
        }
    }
}
