using System.Collections.Generic;
using Entities.Concrete;

namespace DotNetCoreCamp.Models
{
    public class CityAndWriter
    {
        public List<Cities> Cities { get; set; }
        public List<Writer> Writers { get; set; }
    }
}
