using EventsProject.Models.Data;
using EventsProject.Models.Repositories;

namespace EventsProject.Models
{
    public static class DBInitialization
    {
        public static void Init(IDataBase dataBase)
        {
            var places = PlaceListInit(dataBase.PlaceRepository);
            var pictures = PictureListInit(dataBase.PictureRepository);
            InitEvents(dataBase.EventRepository, places, pictures);
        }
        private static void InitEvents(EventRepository eventRepository, List<Place> places, List<Picture> pictures)
        {
            eventRepository.Entities = new List<Event>()
            {
                new Event()
                {
                    Id = Guid.NewGuid(),
                    Name= "Name",
                    Description= "Description",
                    DateStart= DateTime.Now,
                    DateEnd= DateTime.MaxValue,
                    PictureId= pictures.First().Id,
                    PlaceId= places.First().Id,
                }, new Event()
                {
                    Id = Guid.NewGuid(),
                    Name= "Name 2",
                    Description= "Description 2",
                    DateStart= DateTime.MinValue,
                    DateEnd= DateTime.Now,
                    PictureId= pictures.First().Id,
                    PlaceId= places.Last().Id,
                }
            };
        }
        private static List<Place> PlaceListInit(PlaceRepository placeRepository)
        {
            var places = new List<Place>() {
                new Place{
                    Id = Guid.NewGuid(),
                },new Place{
                    Id = Guid.NewGuid(),
                }
            };
            placeRepository.Entities = places;
            return places;
        }
        private static List<Picture> PictureListInit(PictureRepository pictureRepository)
        {
            var pictures = new List<Picture>() {
                new Picture { Id= Guid.NewGuid() },
                new Picture { Id= Guid.NewGuid() }
            };
            pictureRepository.Entities = pictures;
            return pictures;
        }
    }
}
