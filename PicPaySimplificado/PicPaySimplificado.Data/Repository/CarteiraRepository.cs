using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Data.Context;
using PicPaySimplificado.Domain;
using PicPaySimplificado.Domain.Entity;

namespace PicPaySimplificado.Data.Repository;

public class CarteiraRepository : ICarteiraRepository
{
    private readonly ApplicationDbContext _context;

    public CarteiraRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CarteiraEntity carteira)
    {
        await _context.Carteiras.AddAsync(carteira);
    }

    public async Task UpdateAsync(CarteiraEntity carteira)
    {
        _context.Carteiras.Update(carteira);
    }

    public async Task<CarteiraEntity?> GetByCpfCnpj(string cpfCnpj, string email)
    {
        return await _context.Carteiras.FirstOrDefaultAsync(c =>
            c.CPFCNPJ.Equals(cpfCnpj) || c.Email.Equals(email));
    }

    public async Task<CarteiraEntity?> GetById(Guid id)
    {
        return await _context.Carteiras.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}