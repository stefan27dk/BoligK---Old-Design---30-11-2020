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
        public ICollection<Ansøgning> Ansøgninger { get; private set; }
        public Ansøger()
        {
            Ansøgninger = new List<Ansøgning>();

        }
        public void ValidateState()
        {
            if (Email == string.Empty || Fornavn == string.Empty || Efternavn == string.Empty || UserId == string.Empty)
                throw new StateException("Ansøger invalid state");
        }
        public void SetId(string value)
        {
            if (value.Length != 36)
                throw new InvalidIDException("Guid's længde skal være 36 tegn");
            Id = value;
        }
        public void SetEmail(string value)
        {
            //ved godt det ikke er den bedste test af e-mail
            if (!value.Contains("@") || !value.Contains("."))
                throw new InvalidEmailException("E-mail skal indeholde @ og .");
            Email = value;

        }
        public void SetFornavn(string value)
        {
            if (value.Length == 0 || value == string.Empty)
                throw new EmptyStringException("Kan ikke sætte tom streng");
            Fornavn = value;

        }
        public void SetEfternavn(string value)
        {
            if (value.Length == 0 || value == string.Empty)
                throw new EmptyStringException("Kan ikke sætte tom streng");
            Efternavn = value;

        }
        public void SetUserId(string value)
        {
            if (value.Length != 36)
                throw new InvalidIDException("Guid's længde skal være 36 tegn");
            UserId = value;

        }
        public void AddAnsøgning(Ansøgning a)
        {
            //man må kun have 1 aktiv ansøgning
            if (Ansøgninger.Any(x => x.Aktiv == true) && a.Aktiv == true)
                throw new MaxAnsøgningsKapacitetException("Max 1 aktiv ansøgning");
            Ansøgninger.Add(a);
        }

    }
}
