using TemplateFw.Domain.Models.Announces;
using System.Collections.Generic;

#nullable disable

namespace TemplateFw.Domain.Models
{
    public partial class Language
    {
        public Language()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Code { get; set; }
        public bool IsDefault { get; set; }
        public bool IsAvailable { get; set; }


    }
}
