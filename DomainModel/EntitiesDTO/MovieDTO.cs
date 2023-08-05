

using Microsoft.AspNetCore.Http;

namespace DomainModel.EntitiesDTO
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public int year { get; set; }
        public double Rate { get; set; }
        public string StoreLine { get; set; }
        public IFormFile poster { get; set; }
        public int genereId { get; set; }
    }
}
