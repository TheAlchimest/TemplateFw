namespace TemplateFw.Dtos.Dtos
{
    public class ExceptionDto
    {
        public string ExceptionObj { get; set; }

        public string RequestURL { get; set; }

        public bool IsMobileAPI { get; set; }

        public bool IsDocumentAPI { get; set; }
    }
}
