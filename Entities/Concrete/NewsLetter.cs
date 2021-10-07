using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class NewsLetter
    {
        [Key]
        public int MailId { get; set; }
        public string Mail { get; set; }
        public bool MailStatus { get; set; }
    }
}
