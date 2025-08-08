namespace Mindware_Prototip.Entities
{
    public class DeviceData
    {
        public int Id { get; set; }
        public string Mac { get; set; }
        public string? Uuid { get; set; }
        public int Rssi { get; set; }
        public int Battery { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
