namespace BusSystemAnalyzer
{
    /// <summary>
    /// Classe responsável por modelar e analisar um sistema de barramento de computador.
    /// Realiza cálculos de desempenho baseados nas configurações de hardware.
    /// </summary>
    public class BusSystem
    {
        /// <summary>
        /// Nome ou tipo do processador utilizado no sistema (ex: ARM, x86)
        /// </summary>
        public required string nomeProcessador { get; set; }

        /// <summary>
        /// Largura do barramento de dados em bits
        /// </summary>
        public int bits { get; set; }

        /// <summary>
        /// Frequência do barramento em GHz
        /// </summary>
        public decimal frequencia { get; set; }

        /// <summary>
        /// Número de dispositivos conectados ao barramento
        /// </summary>
        public int numeroDispositivos { get; set; }

        /// <summary>
        /// Quantidade de ciclos necessários para completar uma transferência
        /// </summary>
        public decimal ciclos { get; set; }

        /// <summary>
        /// Calcula a Taxa de Transferência Teórica em GB/s.
        /// Representa a velocidade máxima de transferência de dados que o barramento pode atingir em condições ideais.
        /// </summary>
        /// <returns>Taxa de transferência teórica em GB/s</returns>
        /// <exception cref="Exception">Lançada quando o número de ciclos é zero ou negativo</exception>
        public decimal TaxaTransferenciaTeorica()
        {
            if (ciclos <= 0)
            {
                Console.WriteLine("Não é possivel calcular a Taxa pois não existe ciclo!");
            }

            // Converte o resultado de Gbits/s para GB/s dividindo por 8
            var Taxa = Conexao() / 8;

            return Taxa;
        }

        /// <summary>
        /// Calcula a Latência Estimada do barramento, considerando conflitos de acesso.
        /// Representa o tempo que uma operação de transferência leva para ser concluída.
        /// </summary>
        /// <returns>Latência estimada em nanossegundos (ns)</returns>
        public decimal LatenciaEstimada()
        {
            // Cálculo da latência base em nanossegundos
            var latenciaBase = ciclos / frequencia;

            decimal fatorContencao = CalculoFatorContencao(numeroDispositivos);

            decimal latenciaEstimada = latenciaBase * (1 + fatorContencao);

            return latenciaEstimada;
        }

        /// <summary>
        /// Calcula o impacto dos ciclos por transferência no desempenho do sistema.
        /// Quantifica a perda de desempenho em comparação com um sistema ideal de 1 ciclo.
        /// </summary>
        /// <returns>Perda de desempenho em porcentagem (%)</returns>
        public decimal ImpactoCiclosPorTransferencia()
        {
            decimal perdaDesempenho = ((ciclos - 1) / ciclos) * 100;

            return perdaDesempenho;
        }

        /// <summary>
        /// Calcula a Largura de Banda Efetiva, considerando conflitos e atrasos reais.
        /// Representa a taxa de transferência real que o sistema consegue atingir na prática.
        /// </summary>
        /// <returns>Largura de banda efetiva em GB/s</returns>
        public decimal LarguraBandaEfetiva()
        {
            var fatorContencao = CalculoFatorContencao(numeroDispositivos);

            var FatorEficiencia = 1 / (1 + fatorContencao);

            var largura = TaxaTransferenciaTeorica() * FatorEficiencia;

            return largura;
        }

        #region Métodos Privados

        /// <summary>
        /// Calcula a conexão bruta do barramento em Gbits/s.
        /// Fórmula: (bits * frequência) / ciclos
        /// </summary>
        /// <returns>Conexão em Gbits/s</returns>
        private decimal Conexao()
        {
            var conexaoEmGbitsPorSegundo = (bits * frequencia) / ciclos;

            return conexaoEmGbitsPorSegundo;
        }

        /// <summary>
        /// Calcula o fator de contenção baseado no número de dispositivos.
        /// Modelo: cada dispositivo adicional aumenta a contenção em 10%.
        /// </summary>
        /// <param name="dispositivos">Número de dispositivos no barramento</param>
        /// <returns>Fator de contenção (valor decimal entre 0 e N)</returns>
        private decimal CalculoFatorContencao(int dispositivos)
        {
            dispositivos = numeroDispositivos;

            if (dispositivos <= 1) return 0;

            // Modelo linear: cada dispositivo adicional aumenta a contenção em 10%
            return (dispositivos - 1) * 0.1m;
        }

        #endregion
    }
}