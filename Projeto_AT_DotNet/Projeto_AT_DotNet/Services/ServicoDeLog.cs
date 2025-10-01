namespace Projeto_AT_DotNet.Services
{
    //Atv 2
    public static class ServicoDeLog
    {
        public static void LogarNoConsole(string mensagem)
        {
            Console.WriteLine($"[CONSOLE LOG {DateTime.Now:HH:mm:ss}] {mensagem}");
        }

        public static void LogarEmArquivo(string mensagem)
        {
            string logCaminho = Path.Combine(Environment.CurrentDirectory, "log_sistema.txt");

            Console.WriteLine($"[FILE LOG {DateTime.Now:HH:mm:ss}] Gravando em {logCaminho}: {mensagem}");
        }

        public static void LogarNaMemoria(string mensagem)
        {
            Console.WriteLine($"[MEMORY LOG {DateTime.Now:HH:mm:ss}] Armazenando em cache/memória: {mensagem}");
        }
    }

}
