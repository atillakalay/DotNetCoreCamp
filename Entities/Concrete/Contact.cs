using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactUserName { get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
        public bool ContactStatus { get; set; }
    }
}
