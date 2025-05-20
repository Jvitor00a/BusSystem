using BusSystemAnalyzer;
using System;


public class Program
{
    static void Main()
    {
        BoasVindas();

        string nome = ObterNomeProcessador();
        int largura = ObterlarguraBarramento();
        decimal frequencia = ObterFrequenciaBarramento();
        int numeroDispositivos = ObterDispositivosAtivos();
        int numeroCiclos = ObterNumeroDeCiclos();

        BusSystem busSystem = new BusSystem()
        {
            nomeProcessador = nome,
            bits = largura,

        };
    }

    static void BoasVindas()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("    BusSystem Analyzer    ");
        Console.WriteLine("==========================================");
        Console.WriteLine("Este programa vai lhe informar calculos sobre Sistemas Operacionais");
        Console.WriteLine();
    }

    static string ObterNomeProcessador()
    {
        Console.WriteLine("Digite o nome do Processador que esta sendo usado: ");
        string nomeProcessador = Console.ReadLine();
        while (string.IsNullOrEmpty(nomeProcessador))
        {
            Console.WriteLine("Campo não pode estar vazio");
            Console.Write("Digite o nome do Processador que esta sendo usado:");
            nomeProcessador = Console.ReadLine();
        }

        return nomeProcessador;
    }

    static int ObterlarguraBarramento()
    {
        Console.WriteLine("Digite a largura do barramento de dados existente (Em bits ");
        string entrada = Console.ReadLine();

        int larguraBarramento = ValidarRespostaInt(entrada);

        return larguraBarramento;
    }

    static decimal ObterFrequenciaBarramento()
    {
        Console.WriteLine("Digite a Frequência do barramento (Em GHz): ");
        string entrada = Console.ReadLine();

        decimal frequencia = ValidarRespostaDecimal(entrada);

        return frequencia;
    }

    static int ObterDispositivosAtivos()
    {
        Console.WriteLine("Digite o número de dispositivos conectados: ");
        string entrada = Console.ReadLine();

        int numeroDispositivos = ValidarRespostaInt(entrada);

        return numeroDispositivos;
    }

    static int ObterNumeroDeCiclos()
    {
        int ciclos;
        Console.WriteLine("Digite o número de ciclos feitos pela operação: ");

        while (!int.TryParse(Console.ReadLine(), out ciclos))
        {
            Console.WriteLine("Valor Inválido! Digite um valor válido para prosseguir: ");
        }

        return ciclos;
    }


    #region

    private static decimal ValidarRespostaDecimal(string entrada)
    {
        decimal valor;
        bool entradaValida = false;

        if (decimal.TryParse(entrada, out valor) && valor > 0)
        {
            return valor;
        }

        Console.WriteLine("Valor inválido!! Digite um valor válido para prosseguir!");

        while (!entradaValida)
        {
            entrada = Console.ReadLine();
            
            if (decimal.TryParse(entrada, out valor) && valor > 0)
            {
                entradaValida = true;
            }
            else
            {
                Console.WriteLine("Valor inválido!! Digite um valor válido para prosseguir!");
            }
        }

        return valor;
    }

    private static int ValidarRespostaInt(string entrada)
    {
        int valor;
        bool entradaValida = false;

        if (int.TryParse(entrada, out valor) && valor > 0)
        {
            return valor;
        }

        Console.WriteLine("Valor inválido!! Digite um valor válido para prosseguir!");

        while (!entradaValida)
        {
            entrada = Console.ReadLine();

            if (int.TryParse(entrada, out valor) && valor > 0)
            {
                entradaValida = true;
            }
            else
            {
                Console.WriteLine("Valor inválido!! Digite um valor válido para prosseguir!");
            }
        }

        return valor;
    }

    #endregion
}

