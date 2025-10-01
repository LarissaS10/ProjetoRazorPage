namespace Projeto_AT_DotNet.Models
{
    public class DestinoPacote
    {
        //chave estrangeira para PacoteTuristico
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; } 

        public int DestinoId { get; set; }
        public Destino Destino { get; set; }
    }
}
