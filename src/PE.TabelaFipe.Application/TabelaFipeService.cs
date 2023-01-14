using PE.TabelaFipe.Domain;
using PE.TabelaFipe.Domain.Models;
using PE.TabelaFipe.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PE.TabelaFipe.Application
{
    public class TabelaFipeService : ITabelaFipeService
    {
        private readonly ITabelaFipeRepository _tabelaFipeRepository;

        public TabelaFipeService(ITabelaFipeRepository tabelaFipeRepository)
        {
            _tabelaFipeRepository = tabelaFipeRepository;
        }

        public async Task<IEnumerable<Marca>> ObterMarcas(string marca)
        {
            var marcas = await _tabelaFipeRepository.ObterMarcas(marca);

            return marcas;
        }

        public async Task<IEnumerable<Modelo>> ObterModelos(string marca, int codigoMarca)
        {
            var modelosViewModel = await _tabelaFipeRepository.ObterModelos(marca, codigoMarca);

            return modelosViewModel;
        }

        public async Task<IEnumerable<Modelo>> ObterModelosPorAno(string marca, int codigoMarca, int codigoModelo)
        {
            var modelosViewModel = await _tabelaFipeRepository.ObterModelosPorAno(marca, codigoMarca, codigoModelo);

            return modelosViewModel;
        }

        public async Task<Fipe> ObterPreco(string marca, int codigoMarca, int codigoModelo, string codigoAno)
        {
            var fipeViewModel = await _tabelaFipeRepository.ObterPreco(marca, codigoMarca, codigoModelo, codigoAno);

            return fipeViewModel;
        }
    }
}
