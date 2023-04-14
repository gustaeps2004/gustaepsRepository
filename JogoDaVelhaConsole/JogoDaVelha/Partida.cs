using System;
using TabuleiroVelha;
using JogoDaVelha.Enum;

namespace JogoDaVelha
{      
    class Partida
    {
        public bool Terminada { get; private set; }
        public bool Velha { get; set; }
        public int Rodada { get; private set; }
        public Tabuleiro Tabuleiro { get; set; }
        public Formas JogadorAtual { get; private set; }


        public Partida()
        {
            Tabuleiro = new Tabuleiro(3, 3);
            Velha = false;
            Terminada = false;
            Rodada = 1;
            JogadorAtual = Formas.Bolinha;
        }

        private void AlterarRodada()
        {
            Rodada++;
        }

        public void AlterarJogador()
        {
            if(JogadorAtual == Formas.Bolinha)
            {
                JogadorAtual = Formas.Xis;
            }
            else
            {
                JogadorAtual = Formas.Bolinha;
            }
            AlterarRodada();
        }

        public void FimPartida()
        {
            Terminada = true;
        }

        private void ColocarNovaPeca(Posicao posicao, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, posicao);
        }

        public void ColocarPeca(Posicao posicao, Formas jogadorAtual)
        {
            if (jogadorAtual == Formas.Bolinha)
            {
                ColocarNovaPeca(posicao, new Bolinha(Formas.Bolinha, Tabuleiro));
            }
            else 
            {
                ColocarNovaPeca(posicao, new Xis(Formas.Xis, Tabuleiro));
            }
        }


    }
}
