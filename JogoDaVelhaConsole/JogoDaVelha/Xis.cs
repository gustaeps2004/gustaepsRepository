using JogoDaVelha.Enum;
using TabuleiroVelha;

namespace JogoDaVelha
{
    class Xis : Peca
    {
        public Xis(Formas formato, Tabuleiro tabuleiro) : base(formato, tabuleiro)
        {
        }

        public override string ToString()
        {
            return " X ";
        }
    }
}