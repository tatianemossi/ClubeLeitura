using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo : RepositorioBase<Emprestimo>
    {
        private readonly Emprestimo[] emprestimos;

        public RepositorioEmprestimo(int qtdEmprestimos)
        {
            emprestimos = new Emprestimo[qtdEmprestimos];
        }             

        #region Métodos Específicos da Classe
        public bool RegistrarDevolucao(Emprestimo emprestimo)
        {
            emprestimo.Fechar();

            return true;
        }

        public Emprestimo[] SelecionarEmprestimosAbertos()
        {
            Emprestimo[] emprestimosAbertos = new Emprestimo[ObterQuantidadeRegistros()];

            int j = 0;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].estaAberto)
                {
                    emprestimosAbertos[j] = emprestimos[i];
                    j++;
                }
            }

            return emprestimosAbertos;
        }

        public int ObterQtdEmprestimosAbertos()
        {
            int numeroEmprestimos = 0;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].estaAberto)
                    numeroEmprestimos++;
            }

            return numeroEmprestimos;
        }

        #endregion
    }
}
