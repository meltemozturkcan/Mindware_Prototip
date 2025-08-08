using Microsoft.EntityFrameworkCore;

namespace Mindware_Prototip.Context
{
    public class MindwareContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=DESKTOP-IVNGDL6;Database=MindwareDB;integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Entities.DeviceData> DeviceDatas { get; set; } 
        public DbSet<Entities.NRFTerminal> NRFTerminals { get; set; }  
        public DbSet<Entities.Tag> Tags { get; set; }   
    }
}
