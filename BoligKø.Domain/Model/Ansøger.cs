using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model
{
   public class Ansøger:BaseEntity
    {
        public string Email { get; private set; }
        public string Fornavn { get; private set; }
        public string Efternavn { get; private set; }
        public string UserId { get; private set; }

        public ICollection<Ansøgning> Ansøgninger  { get; set; }

        private void ValidateState()
        {

        }
        public void SetEmail(string value)
        {

        }
        public void SetFornavn(string value)
        {
            Fornavn = value;
        }
        public void SetEfternavn(string value)
        {
            Efternavn = value;

        }
        public void SetUserId(string value)
        {

        }
        public void AddAnsøgning(Ansøgning a)
        {
            if (Ansøgninger == null)
                Ansøgninger = new List<Ansøgning>();
            Ansøgninger.Add(a); 
        }
       
    }
}
