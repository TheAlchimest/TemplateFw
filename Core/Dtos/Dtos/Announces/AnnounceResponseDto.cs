using System;
using System.Collections.Generic;

namespace TemplateFw.Dtos.Announces
{
    public class AnnounceResponseDto
    {
        public AnnounceResponseDto()
        {
            AnnounceDetails = new List<AnnounceResponseDetailDto>();
        }

        public int Id { get; set; }
        public int PortalId { get; set; }
        public string CreatedBy { get; set; }
        public bool IsEnabled { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public List<AnnounceResponseDetailDto> AnnounceDetails { get; set; }
    }

    public class AnnounceResponseDetailDto
    {
        public int AnnounceId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Content { get; set; }
    }

    public class AnnounceFullDataDto
    {
        public int AnnounceId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAvailable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public int LanguageId { get; set; }
        public string Content { get; set; }
    }
}
