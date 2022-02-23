using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        List<Writer> GetListWriterById(int id);
    }
}
