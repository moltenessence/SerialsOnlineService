using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.Entities
{
    public class SerialsRatingsEntity : IEntityBase
    {
        public int Id { get; set; }

        public int RatingId { get; set; }
        public int SerialId { get; set; }
    }
}
