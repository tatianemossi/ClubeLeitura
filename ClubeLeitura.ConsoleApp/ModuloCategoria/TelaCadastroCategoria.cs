using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCategoria
{
    public class TelaCadastroCategoria : ITelaCadastroBase<Categoria>, ITelaCadastroEditarExcluirBase
    {
        private readonly RepositorioCategoria repositorioCategoria;
        private readonly Notificador notificador;

        public TelaCadastroCategoria(RepositorioCategoria repositorioCategoria, Notificador notificador)
        {
            this.repositorioCategoria = repositorioCategoria;
            this.notificador = notificador;
        }

        public string MostrarOpcoes()
        {
            MostrarTitulo("Cadastro de Categorias de Revistas");

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Inserir()
        {
            MostrarTitulo("Inserindo nova categoria de revista");

            Categoria novaCategoria = ObterRegistro();

            repositorioCategoria.Inserir(novaCategoria);

            notificador.ApresentarMensagem("Categoria de Revista inserida com sucesso", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Categoria");

            bool temCategoriasCadastradas = Visualizar("Pesquisando");

            if (temCategoriasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma categoria cadastrada para poder editar", TipoMensagem.Atencao);
                return;
            }

            int numeroCategoria = ObterNumeroRegistro();

            Categoria categoriaAtualizada = ObterRegistro();

            repositorioCategoria.Editar(numeroCategoria, categoriaAtualizada);

            notificador.ApresentarMensagem("Categoria editada com sucesso", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Categoria");

            bool temCategoriasCadastradas = Visualizar("Pesquisando");

            if (temCategoriasCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma categoria   cadastrada para poder excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroCategoria = ObterNumeroRegistro();

            repositorioCategoria.Excluir(numeroCategoria);

            notificador.ApresentarMensagem("Revista excluída com sucesso", TipoMensagem.Sucesso);
        }

        public bool Visualizar(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Categorias");

            Categoria[] categorias = repositorioCategoria.ObterTodosRegistros();

            if (categorias.Length == 0)
                return false;

            for (int i = 0; i < categorias.Length; i++)
            {
                Categoria categoria = categorias[i];

                Console.WriteLine("Número: " + categoria.numero);
                Console.WriteLine("Tipo de Categoria: " + categoria.Nome);
                Console.WriteLine("Limite de empréstimo: " + categoria.DiasEmprestimo + " dias");

                Console.WriteLine();
            }

            return true;
        }

        public int ObterNumeroRegistro()
        {
            int numeroCategoria;
            bool numeroCadastroEncontrado;

            do
            {
                Console.Write("Digite o número da categoria que deseja selecionar: ");
                numeroCategoria = Convert.ToInt32(Console.ReadLine());

                numeroCadastroEncontrado = repositorioCategoria.ExisteNumeroRegistro(numeroCategoria);

                if (numeroCadastroEncontrado == false)
                    notificador.ApresentarMensagem("Número de cadastro não encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroCadastroEncontrado == false);

            return numeroCategoria;
        }

        public Categoria ObterRegistro()
        {
            Console.Write("Digite o nome da categoria: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o limite de dias de empréstimo das revistas: ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

            Categoria novaCategoria = new Categoria(nome, diasEmprestimo);

            return novaCategoria;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(titulo);

            Console.ResetColor();

            Console.WriteLine();
        }
    }
}