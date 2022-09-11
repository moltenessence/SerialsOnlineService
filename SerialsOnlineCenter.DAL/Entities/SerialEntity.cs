namespace SerialsOnlineCenter.DAL.Entities
{
    public class SerialEntity
    {
        public int SerialId { get; set; }
        public string Name { get; set; }
        public DateOnly PremierDate { get; set; }
        public int AmountOfSeries { get; set; }
        public string? Description { get; set; }

        public int GenreId { get; set; }
    }
}
