using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRDemoDataAccess.Entities;
using SignalRDemoDataAccess.Repositories;
using SignalRDemoDataAccess.Types;

namespace SignalRDemoDataAccess
{
    public class SignalRDemoContext : DbContext
    {
        public SignalRDemoContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Review> Reviews { get; set;}
        public DbSet<Subject> Subjects { get; set; }

    }
}
