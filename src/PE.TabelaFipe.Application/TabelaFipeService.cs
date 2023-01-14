using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;

        public TabelaFipeService(
            ITabelaFipeRepository tabelaFipeRepository,
            IMemoryCache memoryCache)
        {
            _tabelaFipeRepository = tabelaFipeRepository;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Marca>> ObterMarcas(string marca)
        {
            var key = marca;
            return await _memoryCache.GetOrCreateAsync(key, entry =>
            {
                var marcas = _tabelaFipeRepository.ObterMarcas(marca);

                return marcas;
            });            
        }

        public async Task<IEnumerable<Modelo>> ObterModelos(string marca, int codigoMarca)
        {
            var key = $"{marca}/{codigoMarca}";
            return await _memoryCache.GetOrCreateAsync(key, entry =>
            {
                var modelosViewModel = _tabelaFipeRepository.ObterModelos(marca, codigoMarca);

                return modelosViewModel;
            });            
        }

        public async Task<IEnumerable<Modelo>> ObterModelosPorAno(string marca, int codigoMarca, int codigoModelo)
        {
            var key = $"{marca}/{codigoMarca}/{codigoModelo}";
            return await _memoryCache.GetOrCreateAsync(key, entry =>
            {
                var modelosViewModel = _tabelaFipeRepository.ObterModelosPorAno(marca, codigoMarca, codigoModelo);

                return modelosViewModel;
            });         
        }

        public async Task<Fipe> ObterPreco(string marca, int codigoMarca, int codigoModelo, string codigoAno)
        {
            var key = $"{marca}/{codigoMarca}/{codigoModelo}/{codigoAno}";
            return await _memoryCache.GetOrCreateAsync(key, entry =>
            {
                var fipeViewModel = _tabelaFipeRepository.ObterPreco(marca, codigoMarca, codigoModelo, codigoAno);

                return fipeViewModel;
            });            
        }
    }
}
