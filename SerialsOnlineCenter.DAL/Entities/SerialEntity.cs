using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.Entities
{
    public class SerialEntity : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int AmountOfSeries { get; set; }
        public string? Description { get; set; }
        public string Genre { get; set; }

        public int SubscriptionId { get; set; }
    }
}
