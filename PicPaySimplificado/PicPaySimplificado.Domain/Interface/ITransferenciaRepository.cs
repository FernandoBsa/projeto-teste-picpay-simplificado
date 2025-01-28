using Microsoft.EntityFrameworkCore.Storage;
using PicPaySimplificado.Domain.Entity;

namespace PicPaySimplificado.Domain;

public interface ITransferenciaRepository
{
    Task AddTransaction(TransferenciaEntity transferencia);
    Task SaveChangesAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
}