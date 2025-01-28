using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Domain.Request
{
    public class TransferenciaRequest
    {
        [Required(ErrorMessage = "O campo valor é obrigatório.")]
        public decimal Valor {  get; set; }

        [Required(ErrorMessage = "O campo senderID é obrigatório.")]
        public Guid SenderId { get; set; }

        [Required(ErrorMessage = "O campo reciverId é obrigatório.")]
        public Guid ReceiverId { get; set; }
    }
}
