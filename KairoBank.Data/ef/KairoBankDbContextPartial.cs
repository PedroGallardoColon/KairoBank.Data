using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KairoBank.Data.ef
{
    public partial class KairoBankDbContext
    {
        private readonly string conString;

        public KairoBankDbContext(string conString)
        {
            this.conString = conString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.conString);
            }
        }
    }
}
