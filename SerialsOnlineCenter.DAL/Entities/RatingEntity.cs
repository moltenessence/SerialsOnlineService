using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.Entities
{
    public class RatingEntity : IEntityBase
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string? Annotation { get; set; }
    }
}
