namespace WebApplication1.Models
{
    public class BancoDados
    {
        public static List<Usuario> usuarios = new List<Usuario>();

        public static bool VerificaLogin(string r)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Login.Equals(r))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
