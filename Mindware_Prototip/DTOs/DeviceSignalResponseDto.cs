namespace Mindware_Prototip.DTOs
{
    public class DeviceSignalResponseDto
    {
        public string Mac { get; set; }
        public List<DeviceDataSignalDTOs> Signals { get; set; }
    }
}
