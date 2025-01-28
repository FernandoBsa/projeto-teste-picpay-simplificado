using System.Runtime.CompilerServices;

namespace PicPaySimplificado.Service.Interfaces
{
    public interface IAutorizadorService
    {
        Task<bool> AuthorizeAsync();
    }
}
