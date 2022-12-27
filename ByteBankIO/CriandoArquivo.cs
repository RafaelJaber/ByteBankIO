
using System.Text;

partial class Program
{
    static void CriarArquivo(string conta = "456,7895,4785.40,Gustavo Santos")
    {
        string caminhoNovoArquivo = $"C:\\Developer\\courses\\Alura\\ByteBankIO-master\\retorno\\conta_{DateTime.Now.Ticks}.csv";

        using (FileStream fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            //string contaComoString = "456,7895,4785.40,Gustavo Santos";

            Encoding enconding = Encoding.UTF8;
            byte[] data = enconding.GetBytes(conta);
            
            fluxoDeArquivo.Write(data, 0, data.Length);
            
            fluxoDeArquivo.Close();
        }
    }

    static void CriarArquivoComWriter(string conta = "456,7895,4785.40,Sabrina Santos")
    {
        var caminhoNovoArquivo = $"C:\\Developer\\courses\\Alura\\ByteBankIO-master\\retorno\\conta_writer{DateTime.Now.Ticks}.csv";
        
        using (FileStream fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (StreamWriter escritor = new StreamWriter(fluxoDeArquivo))
        {
            escritor.Write(conta);
        }

        
    }
}