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
        public List<Veiculo> VeiculosUsuario { get; set; }
    }
}
