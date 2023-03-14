using EventsProject.Models.Repositories;

namespace EventsProject.Models
{
    public interface IDataBase
    {
        public EventRepository EventRepository { get; }
        public PictureRepository PictureRepository { get; }
        public PlaceRepository PlaceRepository { get; }

    }
}
