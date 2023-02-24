using System;

namespace TemplateFw.Domain.Models.Announces
{
    public partial class VwAnnounceFullData
    {
        public int AnnounceId { get; set; }
        public int PortalId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAvailable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public DateTime? StartAtivationDate { get; set; }
        public DateTime? EndActivationDate { get; set; }
        public int ActivationCount { get; set; }
        public int LanguageId { get; set; }
        public string Content { get; set; }
        public string PortalName { get; set; }
        public string LanguageName { get; set; }
        public bool IsDefaultLanguage { get; set; }
    }
}
