using PicPaySimplificado.Domain.Entity;

namespace PicPaySimplificado.Domain;

public interface ICarteiraRepository
{
    Task AddAsync(CarteiraEntity carteira);
    Task UpdateAsync(CarteiraEntity carteira);
    Task<CarteiraEntity?> GetByCpfCnpj(string cpfCnpj, string email);
    Task<CarteiraEntity?> GetById(Guid id);
    Task SaveChangesAsync();
}