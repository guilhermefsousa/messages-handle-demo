using NServiceBus;

namespace Messages
{
    public class PedidoFaturado : IEvent
    {
        public PedidoFaturado(PedidoFeito pedido)
        {
            PedidoId = pedido.PedidoId;
        }

        public string PedidoId { get; set; }
    }
}