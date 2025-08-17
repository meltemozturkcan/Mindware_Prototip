using Microsoft.EntityFrameworkCore;

namespace Mindware_Prototip.Context
{
    public class MindwareContext:DbContext
    {
      
        public DbSet<Entities.DeviceData> DeviceDatas { get; set; } 
        public DbSet<Entities.NRFTerminal> NRFTerminals { get; set; }  
        public DbSet<Entities.Tag> Tags { get; set; }   
    }
}
