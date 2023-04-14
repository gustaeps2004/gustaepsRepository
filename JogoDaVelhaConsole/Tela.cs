using System;
using JogoDaVelha;
using TabuleiroVelha;
using JogoDaVelha.Enum;

namespace JogoDaVelhaConsole
{
    class Tela
    {
        public static void ImprimePartida(Partida partida)
        {
            ImprimeTabuleiro(partida.Tabuleiro);
            Console.WriteLine();

            Console.WriteLine(" Jogador atual: " + partida.JogadorAtual);
            Console.WriteLine(" Rodada: " + partida.Rodada);

            if(partida.Terminada && !partida.Velha)
            {
                Console.Clear();
                ImprimeTabuleiro(partida.Tabuleiro);
                Console.WriteLine();

                Console.WriteLine(" VENCEDOR: " + partida.JogadorAtual);
                Console.WriteLine(" TOTAL DE " + partida.Rodada + " RODADAS");
            }
            else if(partida.Velha)
            {
                Console.Clear();
                ImprimeTabuleiro(partida.Tabuleiro);
                Console.WriteLine();

                Console.WriteLine(" DEU VELHAA");
                Console.WriteLine(" JOGO TERMINOU EMPATADO");
            }
        }

        public static void ImprimeTabuleiro(Tabuleiro tabuleiro)
        {
            for(int linha = 0; linha < tabuleiro.Linhas; linha++)
            {
                Console.Write(3 - linha + " ");

                for(int coluna = 0; coluna < tabuleiro.Colunas; coluna++)
                {
                    ImprimePeca(tabuleiro.PegarPeca(linha, coluna));
                }
                Console.WriteLine();    
            }
            Console.WriteLine("   a  b  c");
        }

        public static void ImprimePeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write(" - ");
            }
            else
            {
                if (peca.Formato == Formas.Xis)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
            }
        }

        public static PosicaoNaoTratada PosicaoEscolida()
        {
            string[] posicao = Console.ReadLine().Split(" ");

            int linha = Convert.ToInt32(posicao[0]);
            char coluna = Convert.ToChar(posicao[1]);

            return new PosicaoNaoTratada(linha, coluna); 
        }
    }
}
