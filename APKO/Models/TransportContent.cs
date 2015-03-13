using APKO.Helpers.Enums;

namespace APKO.Models
{
    public class TransportContent
    {
        public State IsPublish { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}