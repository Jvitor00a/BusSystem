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
            frequencia = frequencia,
            numeroDispositivos = numeroDispositivos,
            ciclos = numeroCiclos
        };

        ExibirResultados(busSystem);
    }

    static void BoasVindas()
    {
        Console.WriteLine("\n==========================================");
        Console.WriteLine("              BusSystem Analyzer            ");
        Console.WriteLine("===========================================\n");
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

    static void ExibirResultados(BusSystem busSystem)
    {
        decimal taxa = busSystem.TaxaTransferenciaTeorica();
        decimal latenciaEstimada = busSystem.LatenciaEstimada();
        decimal impacto = busSystem.ImpactoCiclosPorTransferencia();
        decimal largura = busSystem.LarguraBandaEfetiva();

        Console.Clear();

        Console.WriteLine("\n==========================================");
        Console.WriteLine("           RESULTADOS DA ANÁLISE          ");
        Console.WriteLine("==========================================\n");

        Console.WriteLine("\nCONFIGURAÇÃO ANALISADA:");
        Console.WriteLine($"Processador: {busSystem.nomeProcessador}");
        Console.WriteLine($"Largura do barramento: {busSystem.bits} bits");
        Console.WriteLine($"Frequência: {busSystem.frequencia} GHz");
        Console.WriteLine($"Dispositivos conectados: {busSystem.numeroDispositivos}");
        Console.WriteLine($"Ciclos por transferência: {busSystem.ciclos}");

        Console.WriteLine("\nMÉTRICAS DE DESEMPENHO:");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"A Taxa de trasnferência teorica calculada é = {taxa:F2} GB/s");
        Console.WriteLine($"A Latência estimada é = {latenciaEstimada:F2} ns");
        Console.WriteLine($"Temos uma perda de desempenho estimada em {impacto:F2}%");
        Console.WriteLine($"TEmos uma largura de banda efetiva = {largura:F2} GB/s");
        Console.WriteLine("----------------------------------------\n");

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
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

