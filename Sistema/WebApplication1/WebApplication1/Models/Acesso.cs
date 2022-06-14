namespace WebApplication1.Models
{
    public class Acesso
    {
        public int idAcesso { get; set; }
        public int idUsuario { get; set; }
        public int idVeiculo { get; set; }
        DateTime Entrada { get; set; }
        DateTime Saida { get; set; }
    }
}
