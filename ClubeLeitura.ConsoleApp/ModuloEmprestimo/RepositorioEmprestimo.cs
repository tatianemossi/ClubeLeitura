using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo : IRepositorio<Emprestimo>
    {
        private readonly Emprestimo[] emprestimos;
        private int numeroEmprestimo;

        public RepositorioEmprestimo(int qtdEmprestimos)
        {
            emprestimos = new Emprestimo[qtdEmprestimos];
        }

        public void Inserir(Emprestimo emprestimo)
        {
            emprestimo.numero = ++numeroEmprestimo;

            emprestimo.Abrir();

            emprestimo.revista.RegistrarEmprestimo(emprestimo);
            emprestimo.amigo.RegistrarEmprestimo(emprestimo);

            emprestimos[ObterPosicaoVazia()] = emprestimo;
        }
              
        public void Editar(int numeroSelecionado, Emprestimo emprestimo)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i].numero == numeroSelecionado)
                {
                    emprestimo.numero = numeroSelecionado;
                    emprestimos[i] = emprestimo;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i].numero == numeroSelecionado)
                {
                    emprestimos[i] = null;
                    break;
                }
            }
        }

        public Emprestimo[] ObterTodosRegistros()
        {
            Emprestimo[] emprestimosInseridos = new Emprestimo[ObterQuantidadeRegistros()];

            int j = 0;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    emprestimosInseridos[j] = emprestimos[i];
                    j++;
                }
            }

            return emprestimosInseridos;
        }

        public Emprestimo ObterRegistro(int numero)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && numeroEmprestimo == emprestimos[i].numero)
                    return emprestimos[i];
            }

            return null;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int numeroEmprestimos = 0;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                    numeroEmprestimos++;
            }

            return numeroEmprestimos;
        }

        public bool ExisteNumeroRegistro(int numero)
        {
            bool numeroEmprestimoExiste = false;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].numero == numeroEmprestimo)
                {
                    numeroEmprestimoExiste = true;
                    break;
                }
            }

            return numeroEmprestimoExiste;
        }

        public int ObterNumeroRegistro()
        {
            return ++numeroEmprestimo;
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
