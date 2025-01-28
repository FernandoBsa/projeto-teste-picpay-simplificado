using PicPaySimplificado.Domain.DTOs;
using PicPaySimplificado.Domain.Request;
using PicPaySimplificado.Service.Response;

namespace PicPaySimplificado.Service.Interfaces
{
    public interface ITransferenciaService
    {
        Task<Result<TransferenciaDto>> ExecuteAsync(TransferenciaRequest request);
    }
}
