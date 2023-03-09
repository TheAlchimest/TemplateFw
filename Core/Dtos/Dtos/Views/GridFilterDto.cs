using System;
using TemplateFw.Utilities.Helpers;

namespace TemplateFw.Dtos.Views
{
    public class GridFilterDto
    {
        public string Url { get; set; }
        public int PageNo { get; set; }
        public bool HasPortalsFilter { get; set; }
        public bool HasServicesFilter { get; set; }
        public bool HasSearchFilter { get; set; } = true;
        public bool HasAllPortalsOption { get; set; } = true;
        public string PollId { get; set; }
    }

    public class ItemModificationDto
    {
        public string CreationAt {
            get {
                return CreationDate.ConvertToDashboardInputTextDateTime();
            }
        }

        public string ModificationBy {
            get {
                if (string.IsNullOrEmpty(LastModifiedBy))
                    return "";
                return LastModifiedBy;
            }
        }

        public string ModificationAt {
            get {
                if (LastModificationDate == null)
                    return "";
                return LastModificationDate.Value.ConvertToDashboardInputTextDateTime();
            }
        }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }

        public string LastActivationBy { get; set; }
        public DateTime? LastActivationDate { get; set; }
        public string LastDectivationBy { get; set; }
        public DateTime? LastDectivationDate { get; set; }
        public bool ShowTitleReplyBy { get; set; }
    }

}
