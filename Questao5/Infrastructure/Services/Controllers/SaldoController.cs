using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.Sqlite;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoController : ControllerBase
    {
        private IDatabaseBootstrap databaseService;

        public SaldoController(IDatabaseBootstrap _databaseService)
        {
            this.databaseService = _databaseService;
        }

        // GET api/<SaldoController>/5
        [HttpGet("{idContaCorrente}")]
        public object Get(string idContaCorrente)
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

            return this.databaseService.GetSaldo(idContaCorrente);            
        }
    }
}
