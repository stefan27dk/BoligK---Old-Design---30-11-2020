using System;
using System.Collections.Generic;
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

        }
        public void SetAnsøger(Ansøger ansøger)
        {

        }
        public void SetØvrigKommentar(string value)
        {

        }
        public void Addkriterie(IKriterie kriterie)
        {

        }
        public void SetAktiv(bool value)
        {

        }
    }
}
