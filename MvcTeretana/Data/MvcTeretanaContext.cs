using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTeretana.Models;

namespace MvcTeretana.Data
{
    public class MvcTeretanaContext : DbContext
    {
        public MvcTeretanaContext (DbContextOptions<MvcTeretanaContext> options)
            : base(options)
        {
        }

        public DbSet<MvcTeretana.Models.Clan> Clan { get; set; }
    }
}
