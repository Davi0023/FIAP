using Fiap.Web.Challenge.Data.Repository;
using Fiap.Web.Challenge.Data.Contexts;
using Fiap.Web.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Challenge.Data.Repository
{
    public class LocalRepository : ILocalRepository
    {

        private readonly DatabaseContext _databaseContext;

        public LocalRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public void Add(LocalModel local)
        {
            throw new NotImplementedException();
        }

        public void Delete(LocalModel local)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocalModel> GetAll()
        {
            return _databaseContext.Local.ToList();
        }

        public LocalModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(LocalModel local)
        {
            throw new NotImplementedException();
        }
    }
}
