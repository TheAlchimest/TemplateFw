namespace TemplateFw.Dtos.Dtos.Common
{
    public class LookupDto
    {
        public LookupDto()
        {

        }
        public LookupDto(int id , string text)
        {
            Id = id;
            Text = text;
        }
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
