using JogoDaVelha.Enum;
using TabuleiroVelha;

namespace JogoDaVelha
{
    class Bolinha : Peca
    {
        public Bolinha(Formas formato, Tabuleiro tabuleiro) : base(formato, tabuleiro)
        {
        }

        public override string ToString()
        {
            return " O ";
        }
    }
}
