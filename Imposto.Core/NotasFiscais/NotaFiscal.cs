using System;
using System.Collections.Generic;
using Imposto.Core.Pedidos;

namespace Imposto.Core.NotasFiscais
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int Serie { get; set; }
        public string NomeCliente { get; set; }
        public string EstadoDestino { get; set; }
        public string EstadoOrigem { get; set; }

        public List<NotaFiscalItem> ItensNotaFiscal { get; set; }

        public static NotaFiscal New(Pedido pedido)
        {
            var notaFiscal = new NotaFiscal
            {
                NumeroNotaFiscal = 99999,
                Serie = new Random().Next(int.MaxValue),
                NomeCliente = pedido.NomeCliente,
                EstadoDestino = pedido.EstadoDestino,
                EstadoOrigem = pedido.EstadoOrigem
            };

            pedido.ItensDoPedido.ForEach(itemPedido =>
            {
                notaFiscal.ItensNotaFiscal.Add(NotaFiscalItem.New(notaFiscal, itemPedido));
            });

            notaFiscal.Validate();

            return notaFiscal;
        }

        private void Validate()
        {
            // TODO: Validar propriedades da NotaFiscal
        }

        private NotaFiscal()
        {
            ItensNotaFiscal = new List<NotaFiscalItem>();
        }
    }
}