namespace TabuleiroVelha
{
    class PosicaoNaoTratada
    {
        public int Linha { get; private set; }
        public char Coluna { get; private set; }

        public PosicaoNaoTratada(int linha, char coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(3 - Linha, Coluna - 'a');
        }
    }
}
