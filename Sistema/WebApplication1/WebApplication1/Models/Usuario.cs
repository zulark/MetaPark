namespace WebApplication1.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public static List<Usuario> listagem = new List<Usuario>();
        public static List<Veiculo> VeiculosUsuario = new List<Veiculo>();

        static Usuario()
        {
            Usuario.listagem.Add(new Usuario{Id = 0,Name = "Usuario",LastName = "Teste",CPF = "12345678910",Login = "user",Password = "1234",ConfirmPassword = "1234"});
            Usuario.listagem.Add(new Usuario{Id = 1,Name = "User",LastName = "Teste",CPF = "12345678911",Login = "user2",Password = "1234",ConfirmPassword = "1234",});
            Veiculo.listaVeiculos.Add(new Veiculo{IdVeiculo = 0,IdUsuario = 0,Marca = "Ford",Modelo = "KA",Placa = "ABC1234"});
            Veiculo.listaVeiculos.Add(new Veiculo{IdVeiculo = 1,IdUsuario = 0,Marca = "VW",Modelo = "Gol",Placa = "ABC4321"});
            Veiculo.listaVeiculos.Add(new Veiculo{IdVeiculo = 1,IdUsuario = 1,Marca = "VW",Modelo = "Gol",Placa = "ABC9876"});
        }

    }

}