using JogoDaVelha.Enum;
using TabuleiroVelha.Exceptions;

namespace TabuleiroVelha
{
    class Tabuleiro
    {
        public int Linhas { get; private set; }
        public int Colunas { get; private set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca PegarPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca PegarPeca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }
        
        public bool ExistePeca(Posicao posicao)
        {
            ValidaPosicao(posicao);
            return PegarPeca(posicao) != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if(ExistePeca(posicao))
            {
                throw new TabuleiroExceptions("Já existe uma peça nesta posição");
            }

            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        private bool PosicaoValida(Posicao posicao)
        { 
            if(posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;   
            }
            return true;    
        }

        public void ValidaPosicao(Posicao posicao)
        {
            if(!PosicaoValida(posicao))
            {
                throw new TabuleiroExceptions(" Posição inválida");
            }
        }

        public bool ValidaFimPartida(Formas jogadorAtual)
        {
            bool[,] mat = new bool[Linhas, Colunas];

            //Horizontal primeira fila
            if (PegarPeca(0,0) != null && PegarPeca(0, 1) != null && PegarPeca(0, 2) != null)
            {               
                if (Pecas[0, 0].Formato == jogadorAtual && Pecas[0, 1].Formato == jogadorAtual && Pecas[0, 2].Formato == jogadorAtual)
                {
                    return true;
                }
            }

            //Horiontal segunda fila
            if (PegarPeca(1, 0) != null && PegarPeca(1, 1) != null && PegarPeca(1, 2) != null)
            {              
                if (Pecas[1, 0].Formato == jogadorAtual && Pecas[1, 1].Formato == jogadorAtual && Pecas[1, 2].Formato == jogadorAtual)
                {
                    return true;
                }

            }

            //Horizontal terceira fila
            if (PegarPeca(2, 0) != null && PegarPeca(2, 1) != null && PegarPeca(2, 2) != null)
            {               
                if (Pecas[2, 0].Formato == jogadorAtual && Pecas[2, 1].Formato == jogadorAtual && Pecas[2, 2].Formato == jogadorAtual)
                {
                    return true;
                }
            }

            //Vertical primeira fila
            if (PegarPeca(0, 0) != null && PegarPeca(1, 0) != null && PegarPeca(2, 0) != null)
            {                
                if (Pecas[0, 0].Formato == jogadorAtual && Pecas[1, 0].Formato == jogadorAtual && Pecas[2, 0].Formato == jogadorAtual)
                {
                    return true;
                }
            }

            //Vertical segunda fila
            if (PegarPeca(0, 1) != null && PegarPeca(1, 1) != null && PegarPeca(2, 1) != null)
            {               
                if (Pecas[0, 1].Formato == jogadorAtual && Pecas[1, 1].Formato == jogadorAtual && Pecas[2, 1].Formato == jogadorAtual)
                {
                    return true;
                }
            }

            //Vertical terceira fila
            if (PegarPeca(0, 2) != null && PegarPeca(1, 2) != null && PegarPeca(2, 2) != null)
            {                
                if (Pecas[0, 2].Formato == jogadorAtual && Pecas[1, 2].Formato == jogadorAtual && Pecas[2, 2].Formato == jogadorAtual)
                {
                    return true;
                }
            }

            //Diagonal Esquerda para direita
            if (PegarPeca(0, 0) != null && PegarPeca(1, 1) != null && PegarPeca(2, 2) != null)
            {                
                if (Pecas[0, 0].Formato == jogadorAtual && Pecas[1, 1].Formato == jogadorAtual && Pecas[2, 2].Formato == jogadorAtual)
                {
                    return true;
                }
            }

            //Diagonal direita para esquerda
            if (PegarPeca(0, 2) != null && PegarPeca(1, 1) != null && PegarPeca(2, 0) != null)
            {               
                if (Pecas[0, 2].Formato == jogadorAtual && Pecas[1, 1].Formato == jogadorAtual && Pecas[2, 0].Formato == jogadorAtual)
                {
                    return true;
                }
            }

            return false;

        }

        public int DeuVelha()
        {
            int qtdFalsos = 0;
            for(int linha = 0; linha < Linhas; linha++)
            {
                for (int coluna = 0; coluna < Colunas; coluna++)
                {
                    if(PegarPeca(linha, coluna) != null)
                    {
                        qtdFalsos++;
                    }
                }
            }
            return qtdFalsos;
        }
    }
}
