using JogoDaVelha.Enum;
using TabuleiroVelha.Exceptions;

namespace TabuleiroVelha
{
    class Peca
    {
        public Formas Formato { get; private set; }
        public Tabuleiro Tabuleiro { get; private set; }
        public Posicao Posicao { get; set; }

        public Peca(Formas formato,Tabuleiro tabuleiro)
        {
            Posicao = null;
            Formato = formato;
            Tabuleiro = tabuleiro;
        }
    }
}
