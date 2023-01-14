using PE.TabelaFipe.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PE.TabelaFipe.Domain
{
    public interface ITabelaFipeService
    {
        Task<IEnumerable<Marca>> ObterMarcas(string marca);
        Task<IEnumerable<Modelo>> ObterModelos(string marca, int codigoMarca);
        Task<IEnumerable<Modelo>> ObterModelosPorAno(string marca, int codigoMarca, int codigoModelo);
        Task<Fipe> ObterPreco(string marca, int codigoMarca, int codigoModelo, string codigoAno);
    }
}
