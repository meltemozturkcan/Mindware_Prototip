namespace Mindware_Prototip.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string? Description { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
