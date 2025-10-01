using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projeto_AT_DotNet.Models;
using Projeto_AT_DotNet.Services;

namespace Projeto_AT_DotNet.Pages.Descontos
{
    //Atv 4
    public class AlertaCapacidadeModel : PageModel
    {
        public PacoteTuristico Pacote { get; set; }

        public List<string> Alertas { get; set; }
        public string LogSimulacao { get; set; }

        public void OnGet()
        {
            ServicoDeAlerta.LimparAlertas();

            //Pacote = new PacoteTuristico(1, "Amazônia Aventura", 3);

            Pacote.CapacityReached += ServicoDeAlerta.NotificarLimiteAtingido;

            SimularReservas();

            Pacote.CapacityReached -= ServicoDeAlerta.NotificarLimiteAtingido;
            Alertas = ServicoDeAlerta.MensagensDeAlerta;
        }

        private void SimularReservas()
        {
            var log = new StringBuilder();
            log.AppendLine($"Iniciando simulação para o pacote '{Pacote.Titulo}'. Capacidade Máxima: {Pacote.CapacidadeMaxima}.");
            log.AppendLine("--------------------------------------------------------------------------------------------------------------------");

            for (int i = 1; i <= 4; i++)
            {
                if (Pacote.TentarAdicionarParticipante())
                {
                    log.AppendLine($"[Reserva {i}]: Participante adicionado com sucesso. Participantes atuais: {Pacote.ParticipantesAtuais}.");
                }
                else
                {
                    log.AppendLine($"[Reserva {i}]: FALHA. Capacidade Máxima atingida. O evento foi disparado.");
                }
            }

            LogSimulacao = log.ToString();
        }
    }
}
