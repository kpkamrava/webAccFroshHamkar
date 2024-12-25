using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webDb
{
    public class dbContext : DbContext
    {
        //add-migration
        public static string cs { get; set; }
        public string css { get; set; }

        public dbContext()
        {
        }
        public dbContext(string css)
        {
            this.css = css;

        }
        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //    optionsBuilder.UseSqlServer(css ?? cs ?? "Server=.;Database=dbMik;MultipleActiveResultSets=true;user=sa;password=2860120874@",
                //  optionsBuilder.UseSqlServer(css ?? cs ?? "Server=172.16.2.254;Database=dbWMS2;TrustServerCertificate=True;User Id=sa;password=2860120874@@@Kamal;",
                optionsBuilder.UseSqlServer(css ?? cs ?? "Server=10.10.1.222;Database=webAccFroshHamkari;TrustServerCertificate=True;User Id=sa;password=@Neshan@1403 @;",
                sqlServerOptions => sqlServerOptions.CommandTimeout(60));
            }
        }


        public DbSet<tblSales> tblSales { get; set; }
        public DbSet<tblSeller> tblSeller { get; set; }
    }
}
