using System;

namespace TemplateFw.Domain.Models.Announces
{
    public class AnnounceUser
    {
        public AnnounceUser()
        {

        }

        public AnnounceUser(int announceId, Guid userId)
        {
            AnnounceId = announceId;
            UserId = userId;
            CreationDate = DateTime.Now;
        }

        public int AnnounceId { get; set; }
        public Guid UserId { get; set; }


        public virtual Announce Announce { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
