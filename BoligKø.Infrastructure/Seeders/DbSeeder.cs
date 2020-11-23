using BoligKø.Domain.Model;
using BoligKø.Infrastructure.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoligKø.Infrastructure.seeders
{
    public static class DbSeeder
    {
        public static void Seed(BoligKøContext context)
        {

            context.Database.EnsureCreated();
            if (context.Ansøgere.Any())
            {
                //kommenter linjen under ind igen hvis du ikke vil have data bliver seeded ved hver kompilering        
                //return; 
                ClearDatabaseFromTestData(context);
            }

            var ansøgere = GetTestAnsøgere();
            foreach (var a in ansøgere)
                context.Ansøgere.Add(a);

            //var ansøgninger = GetTestAnsøgninger();
            //foreach (var a in ansøgninger)
            //    context.Ansøgninger.Add(a);

            context.SaveChanges();
        }

        private static List<Ansøgning> GetTestAnsøgninger()
        {
            var ansøgninger = new List<Ansøgning>();

            var ansøgning = new Ansøgning { Id = "1" };
            ansøgning.SetAnsøger(new Ansøger { Id = "1" });
            ansøgning.SetØvrigKommentar("Her er min øvrige kommentar");
            ansøgninger.Add(ansøgning);

            return ansøgninger;
        }

        private static void ClearDatabaseFromTestData(BoligKøContext context)
        {
            var ansøgere = context.Set<Ansøger>();
            foreach (var a in ansøgere)
                context.Remove(a);

            var ansøgninger = context.Set<Ansøgning>();
            foreach (var a in ansøgninger)
                context.Remove(a);
            context.SaveChanges();
        }

        private static List<Ansøger> GetTestAnsøgere()
        {
            var ansøgere = new List<Ansøger>();

            var ansøger = new Ansøger {Id = "1"};
            ansøger.SetFornavn("Karl");
            ansøger.SetEfternavn("Mogensen");
            ansøger.SetEmail("karlmogensen@hotmail.com");
            ansøger.SetUserId("123");

            var ansøgning = new Ansøgning { Id = "fisk" };
            ansøgning.SetAnsøger(ansøger);
            ansøgning.SetØvrigKommentar("Her er min øvrige kommentar");


            ansøger.AddAnsøgning(ansøgning);


            ansøgere.Add(ansøger);
            return ansøgere;
        }

    }
}
