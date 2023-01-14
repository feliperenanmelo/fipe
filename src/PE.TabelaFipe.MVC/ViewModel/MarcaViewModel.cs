using System.ComponentModel;

namespace PE.TabelaFipe.MVC.ViewModel
{
    public class MarcaViewModel
    {
        [DisplayName("Marca")]
        public string Nome { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
    }
}
