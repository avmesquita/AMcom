using Microsoft.AspNetCore.Mvc;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        private IDatabaseBootstrap databaseService;

        public MovimentoController(IDatabaseBootstrap _databaseService)
        {
            this.databaseService = _databaseService;
        }


        [HttpPost("Movimentar")]
        public async Task<string> Movimentar(string idReq, string idContaCorrente, double valor, string tipoMovimento)
        {
            var validacaoContaCorrente = this.databaseService.ContaCorrenteExistsActive(idContaCorrente);

            if (!validacaoContaCorrente.Item1)
            {
                throw new BadHttpRequestException("INVALID_ACCOUNT");
            }


            if (!validacaoContaCorrente.Item2)
            {
                throw new BadHttpRequestException("INACTIVE_ACCOUNT");
            }

            if (valor <= 0)
            {
                throw new BadHttpRequestException("INVALID_VALUE");
            }

            if (tipoMovimento.ToUpper() != "C" && tipoMovimento != "D")
            {
                throw new BadHttpRequestException("INVALID_TYPE");
            }

            try
            {
                var resultado = this.databaseService.InsertMovimento(idContaCorrente, tipoMovimento, valor);

                if (resultado != null)
                {
                    return resultado;
                }
                else
                {
                    throw new BadHttpRequestException("INTERNAL_ERROR");
                }
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException(ex.Message);
            }
        }

    }
}
