using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeladeiraSOLID.Models;

namespace GeladeiraSOLID.Data
{
    public class GeladeiraSOLIDContext : DbContext
    {
        public GeladeiraSOLIDContext(DbContextOptions<GeladeiraSOLIDContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}