using Newtonsoft.Json;
using System.Collections.Generic;

namespace PE.TabelaFipe.Domain.Models
{
    public class Modelo
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
    public class DadosModelo
    {
        [JsonProperty("modelos")]
        public IEnumerable<Modelo> Modelos { get; set; }
    }
}
