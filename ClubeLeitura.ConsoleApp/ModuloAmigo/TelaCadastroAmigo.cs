using ClubeLeitura.ConsoleApp.ModuloAmigo;
using System;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroAmigo
    {
        public Amigo[] amigos;
        public int iDAmigo;
        public Notificador notificador;
        public RepositorioAmigo repositorioAmigo;

        public string MostrarOpcoes()
        {
            MostrarTitulo("Cadastro de Amigos");

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo Amigo");

            Amigo novoAmigo = ObterAmigo();

            repositorioAmigo.Inserir(novoAmigo);

            notificador.ApresentarMensagem("Amigo inserido com Sucesso", "Sucesso");
        }

        public Amigo ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereco: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.nome = nome;
            amigo.nomeResponsavel = nomeResponsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;

            return amigo;
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            bool temAmigosCadastrados = VisualizarAmigos("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo cadastrado para editar", "Atencao");
                return;
            }

            int idAmigo = ObterIdAmigo();

            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(idAmigo, amigoAtualizado);

            notificador.ApresentarMensagem("Amigo editado com sucesso", "Sucesso");
        }

        public int ObterIdAmigo()
        {
            int idAmigo;
            bool idAmigoEncontrado;

            do
            {
                Console.Write("Digite o Id do amigo que deseja editar: ");
                idAmigo = Convert.ToInt32(Console.ReadLine());

                idAmigoEncontrado = repositorioAmigo.VerificarIdAmigoExiste(idAmigo);

                if (idAmigoEncontrado == false)
                    notificador.ApresentarMensagem("Id do Amigo não encontrado, digite novamente", "Atencao");



            } while (idAmigoEncontrado == false);

            return idAmigo;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(titulo);

            Console.ResetColor();

            Console.WriteLine();
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temAmigosCadastrados = VisualizarAmigos("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo cadastrado para poder excluir", "Atencao");
                return;
            }

            int idAmigo = ObterIdAmigo();

            repositorioAmigo.Excluir(idAmigo);

            notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
        }

        public bool VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            Amigo[] amigos = repositorioAmigo.SelecionarTodos();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Amigo amigo = amigos[i];

                Console.WriteLine($"Id Amigo: {amigo.idAmigo}");
                Console.WriteLine($"Nome: {amigo.nome}");
                Console.WriteLine($"Nome do Responsável: {amigo.nomeResponsavel} ");
                Console.WriteLine($"Telefone: {amigo.telefone}");
                Console.WriteLine($"Endereço: {amigo.endereco}");

                Console.WriteLine();
            }

            return true;
        }
    }
}
