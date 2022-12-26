using ByteBankIO;

class Program
{
    static void Main(string[] args)
    {
        string enderecoDoArquivo = "C:\\Developer\\courses\\Alura\\ByteBankIO-master\\contas.txt";
        int numeroDeBytesLidos = -1;
        
        
        FileStream fluxoDoARquivo = new FileStream(enderecoDoArquivo, FileMode.Open);
        // public override int Read(byte[] array, int offset, int cout); -- Read do FileStream
        byte[] buffer = new byte[1024]; // 1Kb

        while (numeroDeBytesLidos != 0)
        {
            numeroDeBytesLidos = fluxoDoARquivo.Read(buffer, 0, 1024);
            EscreverBuffer(buffer);

        }
        
        // Devoluções:
        // 0 número total de bytes lidos do buffer. Isso poderá ser menor que o número de
        // bytes solicitado se esse número de bytes não estiver disponível no momento, ou
        // zero, se o final do fluxo for atingido
        
        
        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        foreach (byte b in buffer)
        {
            Console.Write(b);
            Console.Write(" ");
        }
    }
}