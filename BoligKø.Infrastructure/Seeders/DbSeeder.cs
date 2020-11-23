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

            var a1 = CreateAnsøger("1", "Karl", "Mogensen", "karl0844@edu.ucl.dk", "u1");
            var ansøgning = CreateAnsøgning("a1", a1, "Ansøgningens øvrige kommentarer");
            a1.AddAnsøgning(ansøgning);
            ansøgere.Add(a1);


            var a2 = CreateAnsøger("2", "Martin", "Sørensen", "mart95s9@edu.ucl.dk", "u2");
            ansøgere.Add(a2);
            var a3 = CreateAnsøger("3", "Stefan", "Popov", "stef9633@edu.ucl.dk", "u3");
            ansøgere.Add(a3);
            var a4 = CreateAnsøger("4", "Nichlas", "Christensen", "nich1411@edu.ucl.dk", "u4");
            ansøgere.Add(a4);



            ansøgere.Add(a1);
            return ansøgere;
        }

        private static Ansøger CreateAnsøger(string id, string fornavn, string efternavn, string email, string userId)
        {
            var a = new Ansøger { Id = id };
            a.SetFornavn(fornavn);
            a.SetEfternavn(efternavn);
            a.SetEmail(email);
            a.SetUserId(userId);
            return a;
        }

        private static Ansøgning CreateAnsøgning(string id, Ansøger ansøger, string øvrigeKommentare)
        {
            var a = new Ansøgning { Id = id };
            a.SetAnsøger(ansøger);
            a.SetØvrigKommentar(øvrigeKommentare);
            return a;
        }

    }
}
