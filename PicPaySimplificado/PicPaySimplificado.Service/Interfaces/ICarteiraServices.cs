using PicPaySimplificado.Domain.Request;
using PicPaySimplificado.Service.Response;

namespace PicPaySimplificado.Service.Interfaces
{
    public interface ICarteiraServices
    {
        Task<Result<bool>> ExecuteAsync(CarteiraRequest request);
    }
}
