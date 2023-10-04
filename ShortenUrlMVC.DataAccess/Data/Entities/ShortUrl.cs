namespace ShortenUrlMVC.DataAccess.Data.Entities
{
    public class ShortUrl
    {
        public int Id { get; set; }

        public string Short { get; set; }

        public string FullUrl { get; set; }

        public string Owner { get; set; }
    }
}
