using System;
using System.Collections.Generic;
using Imposto.Core.Pedidos;
using Imposto.Core.ValueObjects;

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
                EstadoDestino = new Uf(pedido.EstadoDestino).Value(),
                EstadoOrigem = new Uf(pedido.EstadoOrigem).Value()
            };

            foreach (var itemPedido in pedido.ItensDoPedido)
            {
                notaFiscal.ItensNotaFiscal.Add(NotaFiscalItem.New(notaFiscal, itemPedido));
            }

            notaFiscal.Validate();

            return notaFiscal;
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(NomeCliente))
                throw new Exception("O Nome do Cliente é obrigatório!");

            if (string.IsNullOrEmpty(EstadoOrigem))
                throw new Exception("O Estado Origem é obrigatório!");

            if (string.IsNullOrEmpty(EstadoDestino))
                throw new Exception("O Estado Destino é obrigatório!");

            if (ItensNotaFiscal.Count == 0)
                throw new Exception("É obrigatório vincular itens à Nota Fiscal!");

            if (NomeCliente.Length > 50)
                throw new Exception("O Nome do Cliente é inválido!");
        }

        private NotaFiscal()
        {
            ItensNotaFiscal = new List<NotaFiscalItem>();
        }
    }
}