using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class Ansøger : BaseEntity
    {
        public string Email { get; private set; }
        public string Fornavn { get; private set; }
        public string Efternavn { get; private set; }
        public string UserId { get; private set; }
        public IEnumerable<Ansøgning> Ansøgninger { get; private set; }
        public Ansøger(string mail = null, string forNavn = null, string efterNavn = null, string userId = null, ICollection<Ansøgning> ansøgninger = null)
        {
            Ansøgninger = new List<Ansøgning>();
            if(mail != null || mail != string.Empty)
            {
                SetEmail(mail);
            }
            if(forNavn != null || forNavn != string.Empty)
            {
                SetFornavn(forNavn);
            }
            if(efterNavn != null || efterNavn != string.Empty)
            {
                SetEfternavn(efterNavn);
            }
            if(userId != null || userId != string.Empty)
            {
                SetUserId(userId);
            }    
            if(ansøgninger != null)
            {
                foreach(var ansøgning in ansøgninger)
                {
                    AddAnsøgning(ansøgning);
                }
            }
        }

        private void ValidateState()
        {

        }
        public void SetEmail(string value)
        {
            Email = value;
            ValidateState();

        }
        public void SetFornavn(string value)
        {
            Fornavn = value;
            ValidateState();

        }
        public void SetEfternavn(string value)
        {
            Efternavn = value;
            ValidateState();

        }
        public void SetUserId(string value)
        {
            UserId = value;
            ValidateState();

        }
        public void AddAnsøgning(Ansøgning a)
        {
            //man må kun have 1 aktiv ansøgning
            if (Ansøgninger.Any(x => x.Aktiv == true) && a.Aktiv == true)
                throw new MaxAnsøgningsKapacitetException("Max 1 aktiv ansøgning");
            var temp = Ansøgninger.ToList();
            temp.Add(a);
            Ansøgninger = temp;
            ValidateState();

        }

    }
}
