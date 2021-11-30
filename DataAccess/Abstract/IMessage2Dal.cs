using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetListMessageByWriter(int id);
    }
}
