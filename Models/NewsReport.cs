namespace rapid_news_media_news_api.Models
{
    public class NewsReport
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Category {get; set;}
        public string? Description { get; set; }
        public string? ImageUrl {get; set;}
        public string? Status {get; set;}
        public string? CreatedBy { get; set;}
        public string? CreatedByUsername { get; set;}
        public DateTime? DateCreated {get; set;}
        public DateTime? LastModified {get; set;}
    }
}