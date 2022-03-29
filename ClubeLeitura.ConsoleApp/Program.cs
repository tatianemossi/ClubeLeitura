using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();
            Notificador notificador = new Notificador();

            // Instanciação de Caixas
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            repositorioCaixa.caixas = new Caixa[10];

            TelaCadastroCaixa telaCadastroCaixa = new TelaCadastroCaixa();
            telaCadastroCaixa.repositorioCaixa = repositorioCaixa;
            telaCadastroCaixa.notificador = notificador;

            // Instanciação de Revistas
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            repositorioRevista.revistas = new Revista[10];

            TelaCadastroRevista telaCadastroRevista = new TelaCadastroRevista();
            telaCadastroRevista.notificador = notificador;
            telaCadastroRevista.telaCadastroCaixa = telaCadastroCaixa;
            telaCadastroRevista.repositorioCaixa = repositorioCaixa;
            telaCadastroRevista.repositorioRevista = repositorioRevista;

            // Instanciação de Amigos
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            repositorioAmigo.amigos = new Amigo[10];

            TelaCadastroAmigo telaCadastroAmigo = new TelaCadastroAmigo();
            telaCadastroAmigo.notificador = notificador;
            telaCadastroAmigo.repositorioAmigo = repositorioAmigo;

            // Instanciação de Empréstimos
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            repositorioEmprestimo.emprestimos = new Emprestimo[10];

            TelaCadastroEmprestimo telaCadastroEmprestimo = new TelaCadastroEmprestimo();
            telaCadastroEmprestimo.notificador = notificador;
            telaCadastroEmprestimo.repositorioAmigo = repositorioAmigo;
            telaCadastroEmprestimo.repositorioRevista = repositorioRevista;
            telaCadastroEmprestimo.repositorioEmprestimo = repositorioEmprestimo;
            telaCadastroEmprestimo.telaCadastroAmigo = telaCadastroAmigo;
            telaCadastroEmprestimo.telaCadastroRevista = telaCadastroRevista;

            while (true)
            {
                string opcaoMenuPrincipal = menuPrincipal.MostrarOpcoes();

                if (opcaoMenuPrincipal == "1") 
                {
                    string opcao = telaCadastroCaixa.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroCaixa.InserirNovaCaixa();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroCaixa.EditarCaixa();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroCaixa.ExcluirCaixa();
                    }
                    else if (opcao == "4")
                    {
                        bool temCaixaCadastrada = telaCadastroCaixa.VisualizarCaixas("Tela");

                        if (temCaixaCadastrada == false)
                            notificador.ApresentarMensagem("Nenhuma caixa cadastrada", TipoMensagemEnum.Atencao);

                        Console.ReadLine();
                    }
                }
                else if (opcaoMenuPrincipal == "2") 
                {
                    string opcao = telaCadastroRevista.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroRevista.InserirNovaRevista();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroRevista.EditarRevista();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroRevista.ExcluirRevista();
                    }
                    else if (opcao == "4")
                    {
                        bool temRevistaCadastrada = telaCadastroRevista.VisualizarRevistas("Tela");

                        if (!temRevistaCadastrada)
                            notificador.ApresentarMensagem("Nenhuma revista cadastrada", TipoMensagemEnum.Atencao);

                        Console.ReadLine();
                    }
                }
                else if (opcaoMenuPrincipal == "3") 
                {
                    string opcao = telaCadastroAmigo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroAmigo.InserirNovoAmigo();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroAmigo.EditarAmigo();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroAmigo.ExcluirAmigo();
                    }
                    else if (opcao == "4")
                    {
                        bool temAmigoCadastrado = telaCadastroAmigo.VisualizarAmigos("Tela");

                        if (!temAmigoCadastrado)
                            notificador.ApresentarMensagem("Nenhum amigo cadastrado.", TipoMensagemEnum.Atencao);

                        Console.ReadLine();
                    }
                }
                else if (opcaoMenuPrincipal == "4") 
                {
                    string opcao = telaCadastroEmprestimo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroEmprestimo.InserirNovoEmprestimo();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroEmprestimo.EditarEmprestimo();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroEmprestimo.ExcluirEmprestimo();
                    }
                    else if (opcao == "4")
                    {
                        bool temEmprestimoCadastrado = telaCadastroEmprestimo.VisualizarEmprestimos("Tela");

                        if (!temEmprestimoCadastrado)
                            notificador.ApresentarMensagem("Nenhum empréstimo cadastrado.", TipoMensagemEnum.Atencao);

                        Console.ReadLine();
                    }
                    else if (opcao == "5")
                    {
                        bool temEmprestimoCadastrado = telaCadastroEmprestimo.VisualizarEmprestimosEmAberto("Tela");

                        if (!temEmprestimoCadastrado)
                            notificador.ApresentarMensagem("Nenhum empréstimo em aberto.", TipoMensagemEnum.Atencao);
                    }
                    else if (opcao == "6")
                    {
                        telaCadastroEmprestimo.RegistrarDevolucao();
                    }
                }
            }
        }
    }
}
