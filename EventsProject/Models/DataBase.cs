using EventsProject.Models.Data;
using EventsProject.Models.Repositories;

namespace EventsProject.Models
{
    public class DataBase : IDataBase
    {
        public EventRepository EventRepository { get; } = new();

        public PictureRepository PictureRepository { get; } = new();

        public PlaceRepository PlaceRepository { get; } = new();
    }
}
