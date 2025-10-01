using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Text.Encodings.Web;
namespace Projeto_AT_DotNet.Pages.Arquivos
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _ambiente;

        private readonly HtmlEncoder _htmlEncoder;

        [BindProperty]
        public string NomeArquivo { get; set; }

        [BindProperty]
        public string ConteudoNota { get; set; }

        public List<string> ArquivosDisponiveis { get; set; } = new List<string>();

        public string ConteudoVisualizado { get; set; }
        public string ErroMensagem { get; set; }

        public ViewNotesModel(IWebHostEnvironment ambiente, HtmlEncoder htmlEncoder)
        {
            _ambiente = ambiente;
            _htmlEncoder = htmlEncoder;
        }

        public void OnGet(string nomeArquivoLer)
        {
            string caminhoPasta = Path.Combine(_ambiente.WebRootPath, "files");

            // Garante que a pasta exista
            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }

            //listagem de arquivos (System.IO)
            ArquivosDisponiveis = Directory.GetFiles(caminhoPasta, "*.txt")
                .Select(Path.GetFileName)
                .ToList();

            // 2. Lógica de Leitura de Arquivo
            if (!string.IsNullOrEmpty(nomeArquivoLer))
            {
                string caminhoCompletoArquivo = Path.Combine(caminhoPasta, nomeArquivoLer);

                if (System.IO.File.Exists(caminhoCompletoArquivo))
                {
                    try
                    {
                        string conteudoBruto = System.IO.File.ReadAllText(caminhoCompletoArquivo);

                        ConteudoVisualizado = _htmlEncoder.Encode(conteudoBruto);
                    }
                    catch (IOException ex)
                    {
                        ErroMensagem = $"Erro ao ler o arquivo: {ex.Message}";
                    }
                }
                else
                {
                    ErroMensagem = $"Arquivo '{nomeArquivoLer}' não encontrado.";
                }
            }
        }
        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(NomeArquivo) || string.IsNullOrWhiteSpace(ConteudoNota))
            {
                ErroMensagem = "Nome e Conteúdo da anotação são obrigatórios.";
                OnGet(null); 
                return Page();
            }

            string nomeFinal = NomeArquivo.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) ? NomeArquivo : NomeArquivo + ".txt";
            string caminhoPasta = Path.Combine(_ambiente.WebRootPath, "files");
            string caminhoCompleto = Path.Combine(caminhoPasta, nomeFinal);

            try
            {
                System.IO.File.WriteAllText(caminhoCompleto, ConteudoNota);
                TempData["SuccessMessage"] = $"Anotação '{nomeFinal}' salva com sucesso!";
            }
            catch (IOException ex)
            {
                ErroMensagem = $"Erro ao salvar o arquivo: {ex.Message}";
            }

            return RedirectToPage();
        }
    }
}