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
        public DbSet<Risk_Categories> Risk_Categories { get; set; }
        public DbSet<All_audit_universe> All_Audit_universes { get; set; }
        public DbSet<Add_checklists> Add_checklists { get; set; }
        public DbSet<Assign_Audit> Audit_Assigns_all { get; set; }
        public DbSet<Audit_questions> Audit_questions { get; set; }
        public DbSet<all_assign_task> Audit_tasks { get; set; }
        public DbSet<Task_response> task_Responses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔒 Set all FKs to Restrict by default
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // ✅ You can still override specific FKs if needed here
        }



    }
}
