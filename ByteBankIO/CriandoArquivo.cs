
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

        TestaEscrita();
    }

    static void TestaEscrita()
    {
        var caminhoNovoArquivo = $"C:\\Developer\\courses\\Alura\\ByteBankIO-master\\retorno\\teste.txt";
        
        using (FileStream fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (StreamWriter escritor = new StreamWriter(fluxoDeArquivo))
        {
            escritor.WriteLine("Linha 0");
            for (int i = 0; i < 1000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                escritor.Flush(); // Despeja o buffer para o Stream
                Console.WriteLine($"Linha {i} foi escrita no arquivo.");
                Thread.Sleep(100);
            }
        }
    }

    static void EscritaBinaria()
    {
        var caminhoNovoArquivo = $"C:\\Developer\\courses\\Alura\\ByteBankIO-master\\retorno\\TestaEscrita.txt";
        
        using (FileStream fs = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (BinaryWriter escritor = new BinaryWriter(fs))
        {
            escritor.Write(456);
            escritor.Write(5656564);
            escritor.Write(4000.56);
            escritor.Write("Rafael Jaber");
        }
        Console.WriteLine("Aplicação Finalizada...");
    }

    static void LeituraBinaria()
    {
        var caminhoNovoArquivo = $"C:\\Developer\\courses\\Alura\\ByteBankIO-master\\retorno\\TestaEscrita.txt";
        
        using (FileStream fs = new FileStream(caminhoNovoArquivo, FileMode.Open))
        using (BinaryReader leitor = new BinaryReader(fs))
        {
            var agencia = leitor.ReadInt32();
            var numeroConta = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"{titular} : ag: {agencia}, conta: {numeroConta}, saldo: {saldo}");
        }
    }
}