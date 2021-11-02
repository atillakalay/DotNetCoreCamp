using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        List<Writer> GetListWriterById(int id);
    }
}
