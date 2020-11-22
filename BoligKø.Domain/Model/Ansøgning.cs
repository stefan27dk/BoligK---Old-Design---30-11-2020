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
        public IEnumerable<IKriterie> Kriterier { get; private set; }
        public bool Aktiv { get; private set; }
        public Ansøgning()
        {
            Kriterier = new List<IKriterie>();
        }
        private void ValidateState()
        {
            if (Ansøger == null)
                throw new AnsøgningsNullException("Ingen ansøger koblet på ansøgning");


        }
        public void SetAnsøger(Ansøger ansøger)
        {
            Ansøger = ansøger;
            ValidateState();
        }
        public void SetØvrigKommentar(string value)
        {
            ØvrigKommentar = value;
            ValidateState();

        }
        public void Addkriterie(IKriterie kriterie)
        {
            var temp = Kriterier.ToList();
            temp.Add(kriterie);
            Kriterier = temp;
            ValidateState();

        }
        public void SetAktiv(bool value)
        {
            Aktiv = value;
            ValidateState();

        }
    }
}
