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
            context.SaveChanges();

            var ansøgninger = new List<Ansøgning>();
            for(int i = 0; i < ansøgere.Count; i++)
            {
                var a = ansøgere[i];
                var ansøgning = new Ansøgning { Id = i.ToString()};
                ansøgning.SetAnsøger(a);
                ansøgninger.Add(ansøgning);
            }
            foreach(var ansøgning in ansøgninger)
            {
                context.Ansøgninger.Add(ansøgning);
            }
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
            for(int i = 0; i < 100; i++)
            {
                var a = new Ansøger { Id = i.ToString() };
                a.SetFornavn("fornavn" + i);
                a.SetEfternavn("efternavn" + i);
                ansøgere.Add(a);
            }

            return ansøgere;
        }
        
    }
}
