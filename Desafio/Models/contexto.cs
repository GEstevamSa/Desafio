using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Desafio.Models
{
    public class contexto : DbContext
    {
        public contexto()
        {
            Database.SetInitializer(new DbInitializer());
        }
            
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Clinicas> Clinica { get; set; }
    }

    public class DbInitializer : DropCreateDatabaseIfModelChanges<contexto>
    {
        protected override void Seed(contexto context)
        {
            base.Seed(context);
        }

    }
}