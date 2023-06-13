using DAL.Entities;
using DemoAPI_Complete.DTO;

namespace DemoAPI_Complete.Tools
{
    public static class Mappers
    {
        public static Game ToDal(this GameDTO g)
        {
            return new Game
            {
                Title = g.Title,
                Genre = g.Genre,
                ReleaseYear = g.ReleaseYear,
                Note = g.Note
            };
        }
    }
}
