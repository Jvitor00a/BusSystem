using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSystemAnalyzer
{
    public class BusSystem
    {
        public required string nomeProcessador { get; set; }
        public int bits { get; set; }
        public decimal frequencia { get; set; }
        public int numeroDispositivos { get; set; }
        public decimal ciclos { get; set; }



        /// <summary>
        /// Calcula a Taxa de Transferência Teórica em GB/s
        /// </summary>
        /// <returns>Taxa de transferência em GB/s</returns>
        public decimal TaxaTransferenciaTeorica()
        {
            if (ciclos <= 0)
            {
                Console.WriteLine("Não é possivel calcular a Taxa pois não existe ciclo!");
            }

            var Taxa = Conexao() / 8;

            return Taxa;
        }

        public decimal LatenciaEstimada()
        {
            var latenciaBase = ciclos / frequencia;

            decimal fatorContencao = CalculoFatorContencao(numeroDispositivos);

            decimal latenciaEstimada = latenciaBase * (1 + fatorContencao);

            return latenciaEstimada;
        }

        public decimal LarguraBandaEfetiva()
        {
            var fatorContencao = CalculoFatorContencao(numeroDispositivos);

            var FatorEficiencia = 1 / (1 + fatorContencao);

            var largura = TaxaTransferenciaTeorica() * FatorEficiencia;

            return largura;
        }

        #region Metódos Privados

        /// <summary>
        /// Calcula a conexão bruta em Gbits/s
        /// </summary>
        /// <returns>Conexão em Gbits/s</returns>
        private decimal Conexao()
        {
            var conexaoEmGbitsPorSegundo = (bits * frequencia) / ciclos;

            return conexaoEmGbitsPorSegundo;
        }

        private decimal CalculoFatorContencao(int dispositivos)
        {
            dispositivos = numeroDispositivos;

            if (dispositivos <= 1) return 0;

            return (dispositivos - 1) * 0.1m;
        }

        #endregion
    }
}
