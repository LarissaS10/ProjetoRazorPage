using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projeto_AT_DotNet.Services;

namespace Projeto_AT_DotNet.Pages.Descontos
{
    //Atv 2
    public class RegistroDeLogModel : PageModel
    {
        public string StatusOperacao { get; set; }

        public void OnGet()
        {
            StatusOperacao = "Aguardando simulação de Reserva para registrar logs.";
        }

        public IActionResult OnPostSimularReserva()
        {
            string mensagemDeOperacao = $"OPERAÇÃO: Nova reserva criada. Pacote ID: 5, Cliente ID: 101. Data: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";

            Action<string> logger = null;

            logger += ServicoDeLog.LogarNoConsole;
            logger += ServicoDeLog.LogarEmArquivo;
            logger += ServicoDeLog.LogarNaMemoria;

            if (logger != null)
            {
                logger(mensagemDeOperacao);

                StatusOperacao = "Operação de Reserva e Logs executada com sucesso!";
                ViewData["Sucesso"] = true;
            }
            else
            {
                StatusOperacao = "Erro: Nenhum método de log foi anexado ao delegate.";
                ViewData["Sucesso"] = false;
            }

            return Page();
        }
    }
}
