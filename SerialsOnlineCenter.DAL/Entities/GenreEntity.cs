using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.Entities
{
    public class GenreEntity : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
