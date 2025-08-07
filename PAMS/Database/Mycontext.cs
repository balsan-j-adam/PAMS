using Microsoft.EntityFrameworkCore;
using PAMS.Models;

namespace PAMS.Database
{
    public class Mycontext:DbContext
    {

        public Mycontext(DbContextOptions<Mycontext> options) : base(options) { }

        public DbSet<All_departments> All_departments { get; set; }
        public DbSet<All_positions> All_positions { get; set; }
        public DbSet<All_users> All_users { get; set; }
       
    
}
}
