namespace WebApplication1.Models
{
    public class Veiculo
    {
        public int IdVeiculo { get; set; }
        public int IdUsuario { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }

        public static List<Veiculo> listaVeiculos = new List<Veiculo>();

        public Veiculo()
        {
            Veiculo.listaVeiculos.Add(new Veiculo
            {
                IdVeiculo = 0,
                Marca = "Ford",
                Modelo = "KA",
                Placa = "ABC1234"
            });
            Veiculo.listaVeiculos.Add(new Veiculo
            {
                IdVeiculo = 1,
                Marca = "VW",
                Modelo = "Gol",
                Placa = "ABC1234"
            });
        }

    }
}
