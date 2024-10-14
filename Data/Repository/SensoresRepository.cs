using Fiap.Web.Challenge.Data.Contexts;
using Fiap.Web.Challenge.Data.Repository;
using Fiap.Web.Challenge.Models;
using Microsoft.EntityFrameworkCore;

public class SensoresRepository : ISensoresRepository
{
    private readonly DatabaseContext _context;

    public SensoresRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<SensoresModel> GetAll() => _context.Sensores.Include(c => c.Local).ToList();

    public SensoresModel GetById(int id) => _context.Sensores.Find(id);

    public void Add(SensoresModel sensores)
    {
        _context.Sensores.Add(sensores);
        _context.SaveChanges();
    }

    public void Update(SensoresModel sensores)
    {
        _context.Update(sensores);
        _context.SaveChanges();
    }

    public void Delete(SensoresModel sensores)
    {
        _context.Sensores.Remove(sensores);
        _context.SaveChanges();
    }
}