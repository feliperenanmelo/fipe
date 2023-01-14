using System;
using System.Net;

namespace PE.TabelaFipe.Domain.Models.Exceptions
{
    public class RequestErrorException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }
        public object DadosErro { get; private set; }

        public RequestErrorException(string mensagemErro, HttpStatusCode httpStatusCode, object dadosErro)
            : base(mensagemErro)
        {
            HttpStatusCode = httpStatusCode;
            DadosErro = dadosErro;
        }
    }
}
