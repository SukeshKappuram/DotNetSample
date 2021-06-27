using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ekart.Models;

namespace Ekart.Data
{
    public class EkartContext : DbContext
    {
        public EkartContext (DbContextOptions<EkartContext> options)
            : base(options)
        {
        }
        public DbSet<Ekart.Models.Category> Category { get; set; }
        public DbSet<Ekart.Models.Product> Products { get; set; }
    }
}
