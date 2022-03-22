﻿using System;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();
            TelaCadastroCaixa telaCadastroCaixa = new TelaCadastroCaixa();
            telaCadastroCaixa.caixas = new Caixa[10];
            telaCadastroCaixa.notificador = new Notificador();
            TelaCadastroAmigo telaCadastroAmigo = new TelaCadastroAmigo();
            telaCadastroAmigo.amigos = new Amigo[10];
            telaCadastroAmigo.notificador = new Notificador();


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
                        telaCadastroCaixa.VisualizarCaixas("Tela");
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
                        telaCadastroAmigo.VisualizarAmigos("Tela");
                        Console.ReadLine();
                    }
                }
            }
        }       
    }
}
