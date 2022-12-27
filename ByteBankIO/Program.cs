using ByteBankIO;
using System.Globalization;

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
                string linha = leitor.ReadLine();
                ContaCorrente contaCorrente = ConverterStringParaContaCorrente(linha);

                string msg = $"{contaCorrente.Titular.Nome} : Conta número: {contaCorrente.Numero}, Ag: {contaCorrente.Agencia}, Saldo: {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
            Console.WriteLine("Finalizando a leitura do arquivo utilizando o EndOfStream");
            Console.WriteLine("===============================================================");
            Console.WriteLine();
        }
        CriarArquivo();
        Console.ReadLine();

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            string[] campos = linha.Split(',');

            int agencia = int.Parse(campos[0]);
            int numero = int.Parse(campos[1]);
            double saldoComoDouble = double.Parse(campos[2], CultureInfo.InvariantCulture);
            string nomeTitular = campos[3];

            Cliente titular = new Cliente
            {
                Nome = nomeTitular
            };

            ContaCorrente resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldoComoDouble);
            resultado.Titular = titular;

            return resultado;
        }
    }
    
    

  
}