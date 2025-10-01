using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projeto_AT_DotNet.Services;

namespace Projeto_AT_DotNet.Pages.Descontos
{
    //Atv 1
    public class CalculoDescontoModel : PageModel
    {
        [BindProperty]
        public decimal PrecoDeEntrada { get; set; }

        public decimal PrecoComDesconto { get; set; }

        private CalcularDescontoDelegate _calculadorDeDesconto;

        public void OnGet()
        {
            PrecoDeEntrada = 1000.00M;
            PrecoComDesconto = 0;
        }

        public void OnPost()
        {
            _calculadorDeDesconto = ServicoDeDesconto.AplicarDescontoPacoteTuristico;

            PrecoComDesconto = _calculadorDeDesconto(PrecoDeEntrada);

            ViewData["Mensagem"] = $"Desconto de 10% aplicado com sucesso!";
        }

        //Atv 3
        [BindProperty]
        public int DuracaoEmDias { get; set; }

        [BindProperty]
        public int PrecoDiaria { get; set; } 

        public decimal PrecoTotalReserva { get; set; } 


        public void OnPostCalcularTotal()
        {
            Func<int, int, decimal> calcularValorTotal = (dias, precoDia) =>
            {
                return (decimal)dias * precoDia;
            };

            PrecoTotalReserva = calcularValorTotal(DuracaoEmDias, PrecoDiaria);

            ViewData["SucessoTotal"] = true;
        }
    }
}
