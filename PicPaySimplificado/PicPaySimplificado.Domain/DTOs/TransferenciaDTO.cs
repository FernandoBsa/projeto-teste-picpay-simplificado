using PicPaySimplificado.Domain.Entity;

namespace PicPaySimplificado.Domain.DTOs
{
    public record TransferenciaDto(Guid IdTransaction, CarteiraEntity Sender, CarteiraEntity Reciver, decimal ValorTransferido);
}
