using System.Net.WebSockets;
using PicPaySimplificado.Domain;
using PicPaySimplificado.Domain.DTOs;
using PicPaySimplificado.Domain.Entity;
using PicPaySimplificado.Domain.Enum;
using PicPaySimplificado.Domain.Request;
using PicPaySimplificado.Service.Interfaces;
using PicPaySimplificado.Service.Mappers;
using PicPaySimplificado.Service.Response;

namespace PicPaySimplificado.Service.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IAutorizadorService _autorizadorService;
        private readonly INotificacaoService _notificacaoService;

        public TransferenciaService(ITransferenciaRepository transferenciaRepository, ICarteiraRepository carteiraRepository, IAutorizadorService autorizadorService, INotificacaoService notificacaoService)
        {
            _transferenciaRepository = transferenciaRepository;
            _carteiraRepository = carteiraRepository;
            _autorizadorService = autorizadorService;
            _notificacaoService = notificacaoService;
        }

        public async Task<Result<TransferenciaDto>> ExecuteAsync(TransferenciaRequest request)
        {
            if (!await _autorizadorService.AuthorizeAsync())
                return Result<TransferenciaDto>.Failure("Não Autorizado");

            var pagador = await _carteiraRepository.GetById(request.SenderId);
            var recebedor = await _carteiraRepository.GetById(request.ReceiverId);

            if (pagador == null || recebedor == null)
                return Result<TransferenciaDto>.Failure("Nenhuma Carteira encontrada");

            if (pagador.SaldoConta < request.Valor || pagador.SaldoConta == 0)
                return Result<TransferenciaDto>.Failure("Saldo Insuficiente");

            if(pagador.UserType == UserType.Lojista)
                return Result<TransferenciaDto>.Failure("Lojista não pode efetuar transferencia");

            pagador.DebitarSaldo(request.Valor);
            recebedor.CreditarSaldo(request.Valor);

            var transferencia = new TransferenciaEntity(pagador.Id, recebedor.Id, request.Valor);

            using (var transferenciaScope = await _transferenciaRepository.BeginTransactionAsync())
            {
                try
                {
                    var updateTasks = new List<Task>
                    {
                        _carteiraRepository.UpdateAsync(pagador),
                        _carteiraRepository.UpdateAsync(recebedor),
                        _transferenciaRepository.AddTransaction(transferencia)
                    };

                    await Task.WhenAll(updateTasks);

                    await _carteiraRepository.SaveChangesAsync();
                    await _transferenciaRepository.SaveChangesAsync();

                    await transferenciaScope.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transferenciaScope.RollbackAsync();
                    return Result<TransferenciaDto>.Failure("Erro ao realizar a transferência: " + ex.Message);
                }
            }

            await _notificacaoService.SendNotification();
            return Result<TransferenciaDto>.Success(transferencia.ToTransferenciaDto());
        }
    }
}
