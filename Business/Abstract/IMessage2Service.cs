using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        List<Message2> GetInBoxListMessageByWriter(int id);
        List<Message2> GetSendBoxListMessageByWriter(int id);
    }
}
