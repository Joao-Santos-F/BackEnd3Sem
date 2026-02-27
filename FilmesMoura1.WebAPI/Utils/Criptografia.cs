namespace FilmesMoura1.WebAPI.Utils;

public static class Criptografia
{
    //Criptografa a senha utilazando o algoritmo BCrypt
    public static string GerarHash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    //Compara a senha do formulário com a senha do banco de dados utilizando o algoritmo BCrypt
    public static bool CompararHash(string senhaForm, string senhaBanco)
    {
        return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
    }

}
