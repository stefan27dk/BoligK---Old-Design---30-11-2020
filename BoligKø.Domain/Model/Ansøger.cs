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

        public void SetId(string value)
        {
            Id = value;
            ValiderId();
        }
        public void SetEmail(string value)
        {

            Email = value;
            ValiderEmail();

        }
        public void SetFornavn(string value)
        {
            Fornavn = value;
            ValidateFornavn();
        }
        public void SetEfternavn(string value)
        {
            Efternavn = value;
            ValidateEfternavn();
        }
        public void SetUserId(string value)
        {
            UserId = value;
            ValiderUserId();

        }
        public void AddAnsøgning(Ansøgning a)
        {
            Ansøgninger.Add(a);
            ValidateAnsøgninger();
        }
        public void ValidateState()
        {
            ValidateAttributes();
            ValidateAnsøgninger();
        }
        private void ValidateAttributes()
        {
            ValiderId();
            ValiderUserId();
            ValiderEmail();
            ValidateFornavn();
            ValidateEfternavn();
        }
        private void ValiderId()
        {
            if (Id == null)
                throw new ArgumentNullException("Ansøger Id er null");
            if (Id.Length != 36)
                throw new InvalidIDException("Guid's længde skal være 36 tegn");

        }
        private void ValiderUserId()
        {
            if (UserId.Length != 36)
                throw new InvalidIDException("Guid's længde skal være 36 tegn");

        }
        private void ValiderEmail()
        {
            if (!Email.Contains("@") || !Email.Contains("."))
                throw new InvalidEmailException("E-mail skal indeholde @ og .");
            if (Email == string.Empty || Email == "")
                throw new InvalidEmailException("E-mail kan ikke være tom");

        }
        private void ValidateFornavn()
        {
            if (Fornavn.Length == 0 || Fornavn == string.Empty)
                throw new EmptyStringException("Fornavn kan ikke være tom");
        }
        private void ValidateEfternavn()
        {
            if (Efternavn.Length == 0 || Efternavn == string.Empty)
                throw new EmptyStringException("Efternavn kan ikke være tom");
        }
        private void ValidateAnsøgninger()
        {
            //man må kun have 1 aktiv ansøgning
            var aktiveAnsøgninger = Ansøgninger.Where(x => x.Aktiv == true);
            if (aktiveAnsøgninger.Count() > 1)
                throw new MaxAnsøgningsKapacitetException("Max 1 aktiv ansøgning");
        }

    }
}
