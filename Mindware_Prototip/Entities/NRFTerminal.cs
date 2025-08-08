namespace Mindware_Prototip.Entities
{
    public class NRFTerminal
    {
       
            public int Id { get; set; }
            public string Mac { get; set; }
            public string Name { get; set; }
            public string? Location { get; set; }
            public DateTime LastSeen { get; set; }
            public bool IsDeleted { get; set; }
        
    }
}
