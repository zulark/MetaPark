namespace WebApplication1.Models
{
    public class Acesso
    {
        public int idAcesso { get; set; }
        public int idUsuario { get; set; }
        public int idVeiculo { get; set; }
        public int idLocalEst { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
    }
}
