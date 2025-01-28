using PicPaySimplificado.Domain;
using PicPaySimplificado.Domain.Entity;
using PicPaySimplificado.Domain.Request;
using PicPaySimplificado.Service.Interfaces;
using PicPaySimplificado.Service.Response;

namespace PicPaySimplificado.Service.Services
{
    public class CarteiraServices : ICarteiraServices
    {
        private readonly ICarteiraRepository _repository;

        public CarteiraServices(ICarteiraRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> ExecuteAsync(CarteiraRequest request)
        {
            var carteiraExiste = await _repository.GetByCpfCnpj(request.CPFCNPJ, request.Email);

            if (carteiraExiste != null)
                return Result<bool>.Failure("Carteira já existe");

            CarteiraEntity carteira = new CarteiraEntity(
                request.NomeCompleto,
                request.CPFCNPJ,
                request.Email,
                request.Senha,
                request.UserType,
                request.SaldoConta);

            await _repository.AddAsync(carteira);
            await _repository.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
    }
}
