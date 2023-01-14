using System.ComponentModel;

namespace PE.TabelaFipe.MVC.ViewModel
{
    public class FipeViewModel
    {
        [DisplayName("Preço médio")]
        public string Valor { get; set; }

        [DisplayName("Marca")]
        public string Marca { get; set; }
        
        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [DisplayName("Ano")]
        public int AnoModelo { get; set; }

        [DisplayName("Combustível")]
        public string Combustivel { get; set; }

        [DisplayName("Código Fipe")]
        public string CodigoFipe { get; set; }
        
        [DisplayName("Mês Referência")]
        public string MesReferencia { get; set; }

        [DisplayName("Tipo de veículo")]
        public int TipoVeiculo { get; set; }

        [DisplayName("Sigla do combustível")]
        public char SiglaCombustivel { get; set; }
    }
}
