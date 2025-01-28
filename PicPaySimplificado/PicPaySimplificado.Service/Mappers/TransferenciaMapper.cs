using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicPaySimplificado.Domain.DTOs;
using PicPaySimplificado.Domain.Entity;

namespace PicPaySimplificado.Service.Mappers
{
    public static class TransferenciaMapper
    {
        public static TransferenciaDto ToTransferenciaDto(this TransferenciaEntity transaction)
        {
            return new TransferenciaDto(
                transaction.IdTransferencia,
                transaction.Sender,
                transaction.Receiver,
                transaction.Valor
                );
        }
    }
}
