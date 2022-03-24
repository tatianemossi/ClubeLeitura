using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Instancias

            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();
            TelaCadastroCaixa telaCadastroCaixa = new TelaCadastroCaixa();
            TelaCadastroAmigo telaCadastroAmigo = new TelaCadastroAmigo();
            TelaCadastroRevista telaCadastroRevista = new TelaCadastroRevista();
            

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            repositorioCaixa.caixas = new Caixa[10];

            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            repositorioAmigo.amigos = new Amigo[10];

            RepositorioRevista repositorioRevista = new RepositorioRevista();
            repositorioRevista.revistas = new Revista[10];

            telaCadastroCaixa.repositorioCaixa = repositorioCaixa;
            telaCadastroAmigo.repositorioAmigo= repositorioAmigo;
            telaCadastroRevista.telaCadastroCaixa = telaCadastroCaixa;
            telaCadastroRevista.repositorioCaixa = repositorioCaixa;
            telaCadastroRevista.repositorioRevista = repositorioRevista;


            Notificador notificador = new Notificador();
            telaCadastroCaixa.notificador = notificador;
            telaCadastroAmigo.notificador = notificador;
            telaCadastroRevista.notificador= notificador;
            #endregion

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
                        {
                            notificador.ApresentarMensagem("Nenhuma caixa cadastrada", "Atencao");
                        }
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
                        {
                            notificador.ApresentarMensagem("Nenhuma revista cadastrado", "Atencao");
                        }
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
                        if (temAmigoCadastrado == false)
                        {
                            notificador.ApresentarMensagem("Nenhum amigo cadastrado", "Atencao");
                        }
                        Console.ReadLine();
                    }
                }
            }
        }       
    }
}
