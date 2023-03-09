using System;

namespace TemplateFw.Domain.Models
{
    public class SourceUIApplication
    {
        public SourceUIApplication()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
