using System;

#nullable disable

namespace TemplateFw.Domain.Models
{
    public partial class VwFaq
    {
        public int FaqId { get; set; }
        public string QuestionAr { get; set; }
        public string QuestionEn { get; set; }
        public string AnswerAr { get; set; }
        public string AnswerEn { get; set; }
        public int PortalId { get; set; }
        public int? ServiceId { get; set; }
        public bool IsAvailable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public string PortalNameAr { get; set; }
        public string PortalNameEn { get; set; }
        public string ServiceNameAr { get; set; }
        public string ServiceNameEn { get; set; }
    }
}
