using System.Collections.Generic;

namespace PE.TabelaFipe.MVC.ViewModel
{
    public class FipeDTO
    {
        public string Marca { get; set; }
        public int CodigoMarca { get; set; }
        public int CodigoModelo { get; set; }
        public string CodigoAno { get; set; }

        public List<MarcaViewModel> Marcas { get; set; } = new List<MarcaViewModel>();
        public List<ModeloViewModel> Modelos { get; set; } = new List<ModeloViewModel>();
        public List<ModeloViewModel> ModelosPorAno { get; set; }= new List<ModeloViewModel>();
        public FipeViewModel Fipe { get; set; }
    }
}
