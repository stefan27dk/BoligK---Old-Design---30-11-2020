using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class Ansøgning:BaseEntity
    {
        public Ansøger Ansøger { get; private set; }
        public string ØvrigKommentar { get; private set; }
        public ICollection<Kriterie> Kriterier { get; private set; }
        public bool Aktiv { get; private set; }
        public Ansøgning()
        {
            Kriterier = new List<Kriterie>();
        }
        public void ValidateState()
        {
            if (Ansøger == null)
                throw new StateException("Ingen ansøger koblet på ansøgning");
            foreach(var kriterie in Kriterier)
            {
                var nullCheck = Kriterier.Where(x => x.GetType() == kriterie.GetType()).FirstOrDefault();
                if (nullCheck != null)
                {
                    if (nullCheck.GetType() == typeof(LokationKriterie))
                        continue;
                }
                    else
                        throw new StateException($"{kriterie.ToString()} optræder flere gange, opdater istedet kriteriet.");
            }
            ValiderAttributes();
        }

        private void ValiderAttributes()
        {
            ValiderId();
        }
        private void ValiderId()
        {
            if (Id.Length != 36)
                throw new InvalidIDException("ID længde skal være 36 tegn");
        }
        public void SetId(string value)
        {
            Id = value;
            ValiderId();
        }
        public void SetAnsøger(Ansøger ansøger)
        {
            if (ansøger == null)
                throw new ArgumentNullException("Ansøger var null");
            Ansøger = ansøger;
        }
        public void SetØvrigKommentar(string value)
        {
            if (value.Length == 0 || value == string.Empty)
                throw new EmptyStringException("Kan ikke sætte tom streng");
            ØvrigKommentar = value;

        }
        public void Addkriterie(Kriterie kriterie)
        {
                Kriterier.Add(kriterie);
            ValidateState();
        }
        public void UpdateKriterie(Kriterie kriterie)
        {

        }
        public void SetAktiv(bool value)
        {
            Aktiv = value;
        }
    }
}
