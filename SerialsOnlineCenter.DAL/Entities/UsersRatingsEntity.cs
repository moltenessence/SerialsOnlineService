using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.Entities
{
    public class UsersRatingsEntity : IEntityBase
    {
        public int Id { get; set; }

        public int RatingId { get; set; }
        public int UserId { get; set; }
    }
}
