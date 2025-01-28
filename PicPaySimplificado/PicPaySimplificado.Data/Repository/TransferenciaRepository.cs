using Microsoft.EntityFrameworkCore.Storage;
using PicPaySimplificado.Data.Context;
using PicPaySimplificado.Domain;
using PicPaySimplificado.Domain.Entity;

namespace PicPaySimplificado.Data.Repository;

public class TransferenciaRepository : ITransferenciaRepository
{
    private readonly ApplicationDbContext _context;

    public TransferenciaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddTransaction(TransferenciaEntity transferencia)
    {
        await _context.Transferencias.AddAsync(transferencia);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
}