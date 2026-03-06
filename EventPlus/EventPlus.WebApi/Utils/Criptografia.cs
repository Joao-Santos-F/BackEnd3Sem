namespace EventPlus.WebApi.Utils;

public class Criptografia
{
    //Criptografa a senha utilazando o algoritmo BCrypt
    public static string GerarHash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    //Compara a senha do formulário com a senha do banco de dados utilizando o algoritmo BCrypt
    public static bool CompararHash(string senhaInformada, string senhaBanco)
    {
        return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaBanco);
    }
}
