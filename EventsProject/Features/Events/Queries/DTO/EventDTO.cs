namespace EventsProject.Features.Events.Queries.DTO
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid PictureId { get; set; }
        public Guid PlaceId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
