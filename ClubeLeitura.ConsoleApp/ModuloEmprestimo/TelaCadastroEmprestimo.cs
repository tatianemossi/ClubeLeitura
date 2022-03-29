﻿using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp
{

    public class TelaCadastroEmprestimo
    {
        public Notificador notificador;

        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioRevista repositorioRevista;
        public RepositorioAmigo repositorioAmigo;
        public TelaCadastroRevista telaCadastroRevista;
        public TelaCadastroAmigo telaCadastroAmigo;

        public string MostrarOpcoes()
        {            
            MostrarTitulo("Cadastro de Empréstimos");

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Visualizar empréstimos em aberto");
            Console.WriteLine("Digite 6 para Devolver um empréstimo");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoEmprestimo()
        {
            MostrarTitulo("Inserindo novo Empréstimo");

            Amigo amigoSelecionado = ObtemAmigo();

            if (amigoSelecionado.TemEmprestimoEmAberto())
            {
                notificador.ApresentarMensagem("Este amigo já tem um empréstimo em aberto.", TipoMensagemEnum.Erro);
                return;
            }

            Revista revistaSelecionada = ObtemRevista();

            if (revistaSelecionada.EstaEmprestada())
            {
                notificador.ApresentarMensagem("A revista nesse empréstimo já foi emprestada.", TipoMensagemEnum.Erro);
                return;
            }

            Emprestimo emprestimo = ObtemEmprestimo(amigoSelecionado, revistaSelecionada);

            repositorioEmprestimo.Inserir(emprestimo);

            notificador.ApresentarMensagem("Empréstimo inserido com sucesso", TipoMensagemEnum.Sucesso);
        }

        public void RegistrarDevolucao()
        {
            MostrarTitulo("Devolvendo Empréstimo");

            bool temEmprestimos = VisualizarEmprestimosEmAberto("Pesquisando");

            if (!temEmprestimos)
            {
                notificador.ApresentarMensagem("Nenhum empréstimo disponível para devolução.", TipoMensagemEnum.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            Emprestimo emprestimoParaDevolver = repositorioEmprestimo.SelecionarEmprestimo(numeroEmprestimo);

            if (!emprestimoParaDevolver.EstaAberto)
            {
                notificador.ApresentarMensagem("O empréstimo selecionado não está mais aberto.", TipoMensagemEnum.Atencao);
                return;
            }

            repositorioEmprestimo.RegistrarDevolucao(emprestimoParaDevolver, DateTime.Now);

            notificador.ApresentarMensagem("Devolução concluída com sucesso!", TipoMensagemEnum.Sucesso);
        }

        public void EditarEmprestimo()
        {
            MostrarTitulo("Editando Empréstimos");

            bool temEmprestimosCadastrados = VisualizarEmprestimos("Pesquisando");

            if (temEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma empréstimo cadastrado para poder editar", TipoMensagemEnum.Atencao);
                return;
            }
            int numeroEmprestimo = ObterNumeroEmprestimo();

            Amigo amigoSelecionado = ObtemAmigo();

            Revista revistaSelecionada = ObtemRevista();

            Emprestimo emprestimoAtualizado = ObtemEmprestimo(amigoSelecionado, revistaSelecionada);

            repositorioEmprestimo.Editar(numeroEmprestimo, emprestimoAtualizado);

            notificador.ApresentarMensagem("Empréstimo editado com sucesso", TipoMensagemEnum.Sucesso);
        }

        public void ExcluirEmprestimo()
        {
            MostrarTitulo("Excluindo Empréstimo");

            bool temEmprestimosCadastrados = VisualizarEmprestimos("Pesquisando");

            if (temEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma empréstimo cadastrado para poder excluir", TipoMensagemEnum.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            repositorioEmprestimo.Excluir(numeroEmprestimo);

            notificador.ApresentarMensagem("Revista excluída com sucesso", TipoMensagemEnum.Sucesso);
        }

        public bool VisualizarEmprestimos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Empréstimos");

            Emprestimo[] emprestimos = repositorioEmprestimo.SelecionarTodos();

            if (emprestimos.Length == 0)
                return false;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo emprestimo = emprestimos[i];

                string statusEmprestimo = emprestimo.EstaAberto ? "Aberto" : "Fechado";

                Console.WriteLine("Número: " + emprestimo.Numero);
                Console.WriteLine("Revista emprestada: " + emprestimo.Revista.Colecao);
                Console.WriteLine("Nome do amigo: " + emprestimo.Amigo.Nome);
                Console.WriteLine("Data do empréstimo: " + emprestimo.DataEmprestimo);
                Console.WriteLine("Status do empréstimo: " + statusEmprestimo);
                Console.WriteLine();
            }

            return true;
        }

        public bool VisualizarEmprestimosEmAberto(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Empréstimos em Aberto");

            Emprestimo[] emprestimos = repositorioEmprestimo.SelecionarEmprestimosAbertos();

            if (emprestimos.Length == 0)
                return false;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo emprestimo = emprestimos[i];

                Console.WriteLine("Número: " + emprestimo.Numero);
                Console.WriteLine("Revista emprestada: " + emprestimo.Revista.Colecao);
                Console.WriteLine("Nome do amigo: " + emprestimo.Amigo.Nome);
                Console.WriteLine("Data do empréstimo: " + emprestimo.DataEmprestimo);
                Console.WriteLine();
            }

            return true;
        }

        public Emprestimo ObtemEmprestimo(Amigo amigo, Revista revista)
        {
            Console.Write("Digite a data de devolução prevista do empréstimo: ");
            DateTime dataDevolucao = DateTime.Parse(Console.ReadLine());

            Emprestimo novoEmprestimo = new Emprestimo();

            novoEmprestimo.Amigo = amigo;
            novoEmprestimo.Revista = revista;
            novoEmprestimo.DataDevolucao = dataDevolucao;

            novoEmprestimo.DataEmprestimo = DateTime.Now;

            return novoEmprestimo;
        }

        public Amigo ObtemAmigo()
        {
            bool temAmigosDisponiveis = telaCadastroAmigo.VisualizarAmigos("Pesquisando");

            if (!temAmigosDisponiveis)
            {
                notificador.ApresentarMensagem("Não há nenhum amigo disponível para cadastrar empréstimos.", TipoMensagemEnum.Atencao);
                return null;
            }

            Console.Write("Digite o número do amigo que irá pegar o empréstimo: ");
            int numeroAmigoEmprestimo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Amigo amigoSelecionado = repositorioAmigo.SelecionarAmigo(numeroAmigoEmprestimo);

            return amigoSelecionado;
        }

        public Revista ObtemRevista()
        {
            bool temRevistasDisponiveis = telaCadastroRevista.VisualizarRevistas("Pesquisando");

            if (!temRevistasDisponiveis)
            {
                notificador.ApresentarMensagem("Não há nenhuma revista disponível para cadastrar empréstimos.", TipoMensagemEnum.Atencao);
                return null;
            }

            Console.Write("Digite o número da revista que irá será emprestada: ");
            int numeroRevistaEmprestimo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Revista revistaSelecionada = repositorioRevista.SelecionarRevista(numeroRevistaEmprestimo);

            return revistaSelecionada;
        }

        public int ObterNumeroEmprestimo()
        {
            int numeroEmprestimo;
            bool numeroEmprestimoEncontrado;

            do
            {
                Console.Write("Digite o número do empréstimo que deseja selecionar: ");
                numeroEmprestimo = Convert.ToInt32(Console.ReadLine());

                numeroEmprestimoEncontrado = repositorioEmprestimo.VerificarNumeroEmprestimoExiste(numeroEmprestimo);

                if (numeroEmprestimoEncontrado == false)
                    notificador.ApresentarMensagem("Número de empréstimo não encontrado, digite novamente", TipoMensagemEnum.Atencao);

            } while (numeroEmprestimoEncontrado == false);
            return numeroEmprestimo;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(titulo);

            Console.Clear();

            Console.WriteLine();
        }
    }
}
