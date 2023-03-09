using System;
using System.Collections.Generic;
using TemplateFw.Shared.Domain.Interfaces;

namespace TemplateFw.Domain.Models.Announces
{
    public partial class Announce : IAgregateEntity
    {
        public Announce()
        {
            AnnounceDetails = new HashSet<AnnounceDetail>();
        }

        public int Id { get; set; }
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


        public string LastActivationBy { get; set; }
        public DateTime? LastActivationDate { get; set; }

        public string LastDectivationBy { get; set; }
        public DateTime? LastDectivationDate { get; set; }


        public virtual Portal Portal { get; set; }
        public virtual ICollection<AnnounceDetail> AnnounceDetails { get; set; }
        public virtual ICollection<AnnounceUser> AnnounceUsers { get; set; }
    }
}
