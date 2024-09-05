using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeladeiraApiBD.Models;
using Microsoft.EntityFrameworkCore;

namespace GeladeiraApiBD.Data
{
    public class GeladeiraApiDbContext : DbContext
    {
         public GeladeiraApiDbContext(DbContextOptions<GeladeiraApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Itens { get; set; }
    }
}

