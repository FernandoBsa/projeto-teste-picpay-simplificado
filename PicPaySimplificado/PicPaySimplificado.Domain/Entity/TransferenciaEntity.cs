namespace PicPaySimplificado.Domain.Entity;

public class TransferenciaEntity
{
    public Guid IdTransferencia { get; set; }
    public Guid SenderId { get; set; }
    public CarteiraEntity Sender { get; set; }
    public Guid ReceiverId { get; set; }
    public CarteiraEntity Receiver { get; set; }
    public decimal Valor { get; set; }

    private TransferenciaEntity() { }

    public TransferenciaEntity(Guid senderId, Guid receiverId, decimal valor)
    {
        SenderId = senderId;
        ReceiverId = receiverId;
        Valor = valor;
    }


}