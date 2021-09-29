using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICommentService
    {
        void Add(Comment comment);
        void Delete(Comment comment);
        void Update(Comment comment);
        List<Comment> GetAll();
        List<Comment> GetAll(int id);
        Blog GetById(int id);
    }
}
