using System;
using System.Data;
using System.Windows.Forms;
using Imposto.Core.NotasFiscais.Interfaces;
using Imposto.Core.Pedidos;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private readonly INotaFiscalService _notaFiscalService;

        public FormImposto(INotaFiscalService notaFiscalService)
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();

            _notaFiscalService = notaFiscalService;
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width /
                                dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (var i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }
        }

        private object GetTablePedidos()
        {
            var table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));

            return table;
        }

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            var table = (DataTable) dataGridViewPedidos.DataSource;

            var pedido = new Pedido
            {
                EstadoOrigem = txtEstadoOrigem.Text,
                EstadoDestino = txtEstadoDestino.Text,
                NomeCliente = textBoxNomeCliente.Text
            };

            foreach (DataRow row in table.Rows)
            {
                pedido.ItensDoPedido.Add(new PedidoItem
                {
                    Brinde = Convert.ToBoolean(row["Brinde"]),
                    CodigoProduto = row["Codigo do produto"].ToString(),
                    NomeProduto = row["Nome do produto"].ToString(),
                    ValorItemPedido = Convert.ToDouble(row["Valor"].ToString())
                });
            }

            _notaFiscalService.GerarNotaFiscal(pedido);
            MessageBox.Show(@"Operação efetuada com sucesso");
        }
    }
}