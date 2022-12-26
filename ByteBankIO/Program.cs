partial class Program
{
    static void Main(string[] args)
    {
        string enderecoDoArquivo = "C:\\Developer\\courses\\Alura\\ByteBankIO-master\\contas.txt";

        using (FileStream fluxoDeArquivos = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            StreamReader leitor = new StreamReader(fluxoDeArquivos);

            // Console.WriteLine($"Realizando a leitura de uma linha: {leitor.ReadLine()}");
            // Console.WriteLine();
            //
            // Console.WriteLine("===============================================================");
            // Console.WriteLine("Realizando a leitura de t odo o arquivo com o ReadToEnd");
            // string texto = leitor.ReadToEnd();
            // Console.WriteLine(texto);
            // Console.WriteLine("Finalizada a leitura do arquivo t odo com o ReadToEnd");
            // Console.WriteLine("===============================================================");
            // Console.WriteLine();

            Console.WriteLine("===============================================================");
            Console.WriteLine("Realizando a leitura do arquivo utilizando o EndOfStream");
            while (!leitor.EndOfStream)
            {
                Console.WriteLine(leitor.ReadLine());
            }
            Console.WriteLine("Finalizando a leitura do arquivo utilizando o EndOfStream");
            Console.WriteLine("===============================================================");
            Console.WriteLine();
        }
        
        Console.ReadLine();
    }

  
}