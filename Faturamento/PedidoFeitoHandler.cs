using Messages;
using System.Threading.Tasks;

namespace Faturamento
{
    public class PedidoFeitoHandler : IHandleMessages<PedidoFeito>
    {
        private static ILog _log = LogManager.GetLogger<PedidoFeitoHandler>();

        public Task Handle(PedidoFeito message, IMessageHandlerContext context)
        {
            _log.Info($"PedidoFeito Recebido, PedidoId = {message.PedidoId} - Cobrando cartão de crédito...");

            var pedidoFaturado = new PedidoFaturado(message);

            _log.Info($"PedidoFaturado Concluido, disparando evento de PedidoFaturado, PedidoId: {message.PedidoId}");
            return context.Publish(pedidoFaturado);
        }
    }
}