using System;
using JogoDaVelha;
using TabuleiroVelha;
using TabuleiroVelha.Exceptions;

namespace JogoDaVelhaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Partida partida = new Partida();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();

                        Tela.ImprimePartida(partida);
                        Console.WriteLine();

                        Console.Write(" Escolha uma posição válida: ");
                        Posicao posicao = Tela.PosicaoEscolida().ToPosicao();

                        partida.Tabuleiro.ValidaPosicao(posicao);
                        partida.ColocarPeca(posicao, partida.JogadorAtual);

                        if (partida.Tabuleiro.ValidaFimPartida(partida.JogadorAtual))
                        {
                            partida.FimPartida();
                        }
                        else
                        {
                            if (partida.Tabuleiro.DeuVelha() == 9)
                            {
                                partida.Velha = true;
                                partida.FimPartida();
                            }
                            partida.AlterarJogador();
                        }

                    }
                    catch (TabuleiroExceptions ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Error: " + ex.Message);
                        Console.ReadLine();
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Erro durante a escolha da posição!! Formato Correto (linha coluna)");
                        Console.ReadLine();
                    }
                }
                Tela.ImprimePartida(partida);
            }
            catch (TabuleiroExceptions ex)
            {
                Console.WriteLine(" Internal Error: " + ex.Message);
            }
        }
    }
}