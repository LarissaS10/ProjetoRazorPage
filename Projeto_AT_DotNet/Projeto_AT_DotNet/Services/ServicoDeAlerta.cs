using Projeto_AT_DotNet.Models;

namespace Projeto_AT_DotNet.Services
{
    //Atv 4
    public static class ServicoDeAlerta
    {
        public static List<string> MensagensDeAlerta = new List<string>();

        public static void NotificarLimiteAtingido(PacoteTuristico pacote)
        {
            string alerta = $"O Pacote {pacote.Titulo} atingiu a capacidade máxima de {pacote.CapacidadeMaxima} participantes.";

            MensagensDeAlerta.Add(alerta);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[CONSOLE DEBUG] {alerta}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LimparAlertas()
        {
            MensagensDeAlerta.Clear();
        }
    }
}
