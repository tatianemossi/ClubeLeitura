
using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa : IRepositorio<Caixa>
    {
        private readonly Caixa[] caixas;
        private int numeroCaixa;

        public RepositorioCaixa(int qtdCaixas)
        {
            caixas = new Caixa[qtdCaixas];
        }

        public void Inserir(Caixa caixa)
        {
            caixa.numero = ++numeroCaixa;

            int posicaoVazia = ObterPosicaoVazia();
            caixas[posicaoVazia] = caixa;
        }

        public void Editar(int numeroSelecioando, Caixa caixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].numero == numeroSelecioando)
                {
                    caixa.numero = numeroSelecioando;
                    caixas[i] = caixa;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].numero == numeroSelecionado)
                {
                    caixas[i] = null;
                    break;
                }
            }
        }

        public Caixa[] ObterTodosRegistros()
        {
            int quantidadeCaixas = ObterQuantidadeRegistros();

            Caixa[] caixasInseridas = new Caixa[quantidadeCaixas];

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                    caixasInseridas[i] = caixas[i];
            }

            return caixasInseridas;
        }

        public Caixa ObterRegistro(int numero)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && numeroCaixa == caixas[i].numero)
                    return caixas[i];
            }

            return null;
        }

        public bool ExisteNumeroRegistro(int numero)
        {
            bool numeroCaixaEncontrado = false;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].numero == numeroCaixa)
                {
                    numeroCaixaEncontrado = true;
                    break;
                }
            }

            return numeroCaixaEncontrado;
        }

        public int ObterQuantidadeRegistros()
        {
            int numeroCaixas = 0;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                    numeroCaixas++;
            }

            return numeroCaixas;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterNumeroRegistro()
        {
            return ++numeroCaixa;
        }

        #region Métodos Específicos da Classe
        public bool EtiquetaJaUtilizada(string etiquetaInformada)
        {
            bool etiquetaJaUtilizada = false;
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].Etiqueta == etiquetaInformada)
                {
                    etiquetaJaUtilizada = true;
                    break;
                }
            }

            return etiquetaJaUtilizada;
        }
        #endregion
    }
}
