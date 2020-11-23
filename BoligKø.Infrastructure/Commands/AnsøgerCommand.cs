using BoligKø.Domain.Model;
using BoligKø.Infrastructure.patterns;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Infrastructure.Commands
{
    public class AnsøgerCommand
    {
        private readonly Repository<Ansøger> repository;
        public AnsøgerCommand (Repository<Ansøger> repository)
        {
            this.repository = repository;
        }


    }
}
