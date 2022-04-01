
using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa : RepositorioBase<Caixa>
    {
        private readonly Caixa[] caixas;

        public RepositorioCaixa(int qtdCaixas)
        {
            caixas = new Caixa[qtdCaixas];
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
