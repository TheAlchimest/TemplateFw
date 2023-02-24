namespace TemplateFw.Domain.Models.Announces
{
    public partial class AnnounceDetail
    {
        public int AnnounceId { get; set; }
        public int LanguageId { get; set; }
        public string Content { get; set; }

        public virtual Announce Announce { get; set; }
        public virtual Language Language { get; set; }
    }
}
