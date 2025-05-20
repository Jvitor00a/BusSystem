using BusSystemAnalyzer;
using System;


public class Program
{
    static void Main()
    {
        Console.WriteLine("Seja bem vindo ao BusSystemAnalyzer");

        Console.WriteLine("\nPode por favor me dizer qual o tipo de processador você está usando?");
        string? nomeProcessador = Console.ReadLine();

        if (string.IsNullOrEmpty(nomeProcessador))
        {
            Console.WriteLine("O nome do processador não pode ser vazio. Encerrando o programa.");
            return;
        }

        Console.WriteLine("Quantos bits ele possui?");
        if (!int.TryParse(Console.ReadLine(), out int bits))
        {
            Console.WriteLine("Entrada inválida para bits. Encerrando o programa.");
            return;
        }

        Console.WriteLine("Qual a frequência (em GHz)?");
        if (!decimal.TryParse(Console.ReadLine(), out decimal frequencia))
        {
            Console.WriteLine("Entrada inválida para frequência. Encerrando o programa.");
            return;
        }

        Console.WriteLine("Quantos dispositivos estão conectados ao barramento?");
        if (!int.TryParse(Console.ReadLine(), out int numeroDispositivos))
        {
            Console.WriteLine("Entrada inválida para número de dispositivos. Encerrando o programa.");
            return;
        }

        Console.WriteLine("Quantos ciclos o barramento realiza por operação?");
        if (!decimal.TryParse(Console.ReadLine(), out decimal ciclos))
        {
            Console.WriteLine("Entrada inválida para ciclos. Encerrando o programa.");
            return;
        }

        BusSystem busSystem = new BusSystem()
        {
            nomeProcessador = nomeProcessador,
            bits = bits,
            frequencia = frequencia,
            numeroDispositivos = numeroDispositivos,
            ciclos = ciclos
        };


    }
}

