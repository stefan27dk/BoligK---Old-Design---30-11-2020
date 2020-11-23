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

        public string UserId { get; set; }

        [MaxLength(500, ErrorMessage = "Komentar kan ikke overskride 200 bogstaver")]
        [Display(Name = "Øvrige Kommentar")]   
        [Required]
        public string ØvrigeKommentar { get; set; }


        [Range(0,99999, ErrorMessage = "Fra m2 - Maks 5 tegn er tilladt")]
        [Display(Name = "Fra m2")]
        [Required]
        public double FraKvm { get; set; }


        [Range(0,99999, ErrorMessage = "Til m2 - Maks 5 tegn er tilladt")]
        [CompareNumbers("FraKvm", ErrorMessage = "Til m2 skal være større end Fra m2")]
        [Display(Name = "Til m2")]    
        [Required]
        public double TilKvm { get; set; }


        [Range(0,99999, ErrorMessage = "Fra Pris - Maks 5 tegn er tilladt")]
        [Display(Name = "Fra Pris")]     
        [Required]
        public double FraPris { get; set; }


        [Range(0,99999, ErrorMessage = "Til Pris - Maks 5 tegn er tilladt")]
        [CompareNumbers("FraPris", ErrorMessage = "Til Pris skal være større end Fra Pris")] // On Submit Validation
        [Display(Name = "Til Pris")]   
        [Required]
        public double TilPris { get; set; }


        [Range(0,99, ErrorMessage = "Fra Antal Værelser - Maks 2 tal er tilladt")]
        [Display(Name = "Fra Antal Værelser")]
        [Required]
        public int FraAntalVærelser { get; set; }


        [Range(0,99, ErrorMessage = "Til Antal Værelser - Maks 2 tal er tilladt")]  
        [CompareNumbers("FraAntalVærelser", ErrorMessage = "Til Antal Værelser skal være større end Fra Antal Værelser")]  
        [Display(Name = "Til Antal Værelser")]     
        [Required]
        public int TilAntalVærelser { get; set; }
                


        [Display(Name = "Små Dyr")]    
        [Required]
        public bool SmåDyr { get; set; }



        [Display(Name ="Stor Dyr")]   
        [Required]
        public bool StorDyr { get; set; }


        [Range(0,9999, ErrorMessage = "Post Nr - Maks 4 tal er tilladt")]  
        [Display(Name = "Post Nr")]    
        [Required]
        public int PostNr { get; set; }



        [Display(Name ="Lejemåls Type")]
        [Required]
        public LejemålTypeKriterie LejemålsType { get; set; }
        //public IEnumerable<IKriterie> Kriterier { get; private set; }








        // Custome Anotation - || Class ||
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
