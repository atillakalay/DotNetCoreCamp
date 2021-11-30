using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        List<Message2> GetListMessageByWriter(int id);
    }
}
