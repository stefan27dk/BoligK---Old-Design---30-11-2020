﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoligKø.Domain.Model
{
    public class Ansøgning:BaseEntity
    {
        public Ansøger Ansøger { get; private set; }
        public string ØvrigKommentar { get; private set; }
        public ICollection<IKriterie> Kriterier { get; private set; }
        public bool Aktiv { get; private set; }
        public Ansøgning()
        {
            Kriterier = new List<IKriterie>();
        }
        public void ValidateState()
        {
            if (Ansøger == null)
                throw new StateException("Ingen ansøger koblet på ansøgning");
            

        }
        public void SetId(string value)
        {
            if (value.Length != 36)
                throw new InvalidIDException("Guid's længde skal være 36 tegn");
            Id = value;
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
        public void Addkriterie(IKriterie kriterie)
        {
            var type = kriterie.GetType();
            var nullCheck = Kriterier.Where(x => x.GetType() == kriterie.GetType()).FirstOrDefault();
            if (nullCheck == null)
                Kriterier.Add(kriterie);
            else throw new StateException("1 kriterie kan kun  optræde 1 gang, opdater istedet");
        }
        public void UpdateKriterie(IKriterie kriterie)
        {

        }
        public void SetAktiv(bool value)
        {
            Aktiv = value;
        }
    }
}
