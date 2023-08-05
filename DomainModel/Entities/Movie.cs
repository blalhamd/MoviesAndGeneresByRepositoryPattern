

namespace DomainModel.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int year { get; set; }
        public double Rate { get; set; }
        public string StoreLine { get; set; }
        public byte[] poster { get; set; }
        public Genere genere { get; set; }
        public int genereId { get; set; }

    }
}
