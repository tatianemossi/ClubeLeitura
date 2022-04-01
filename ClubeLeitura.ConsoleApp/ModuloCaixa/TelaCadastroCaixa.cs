using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCadastroCaixa : ITelaCadastroBase<Caixa>, ITelaCadastroEditarExcluirBase
    {
        private readonly Notificador notificador;
        private readonly RepositorioCaixa repositorioCaixa;

        public TelaCadastroCaixa(RepositorioCaixa repositorioCaixa, Notificador notificador)
        {
            this.repositorioCaixa = repositorioCaixa;
            this.notificador = notificador;
        }

        public string MostrarOpcoes()
        {
            MostrarTitulo("Cadastro de Caixas");

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
            MostrarTitulo("Inserindo nova Caixa");

            Caixa novaCaixa = ObterRegistro();

            repositorioCaixa.Inserir(novaCaixa);

            notificador.ApresentarMensagem("Caixa inserida com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Caixa");

            bool temCaixasCadastradas = Visualizar("Pesquisando");

            if (temCaixasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma caixa cadastrada para poder editar", TipoMensagem.Atencao);
                return;
            }

            int numeroCaixa = ObterNumeroRegistro();

            Caixa caixaAtualizada = ObterRegistro();

            repositorioCaixa.Editar(numeroCaixa, caixaAtualizada);

            notificador.ApresentarMensagem("Caixa editada com sucesso", TipoMensagem.Sucesso);
        }

        public int ObterNumeroRegistro()
        {
            int numeroCaixa;
            bool numeroCaixaEncontrado;

            do
            {
                Console.Write("Digite o número da caixa que deseja editar: ");
                numeroCaixa = Convert.ToInt32(Console.ReadLine());

                numeroCaixaEncontrado = repositorioCaixa.ExisteNumeroRegistro(numeroCaixa);

                if (numeroCaixaEncontrado == false)
                    notificador.ApresentarMensagem("Número de caixa não encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroCaixaEncontrado == false);
            return numeroCaixa;
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Caixa");

            bool temCaixasCadastradas = Visualizar("Pesquisando");

            if (temCaixasCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma caixa cadastrada para poder excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroCaixa = ObterNumeroRegistro();

            repositorioCaixa.Excluir(numeroCaixa);

            notificador.ApresentarMensagem("Caixa excluída com sucesso", TipoMensagem.Sucesso);
        }

        public bool Visualizar(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Caixas");

            Caixa[] caixas = repositorioCaixa.ObterTodosRegistros();

            if (caixas.Length == 0)
                return false;

            for (int i = 0; i < caixas.Length; i++)
            {
                Caixa c = caixas[i];

                Console.WriteLine("Número: " + c.numero);
                Console.WriteLine("Cor: " + c.Cor);
                Console.WriteLine("Etiqueta: " + c.Etiqueta);

                Console.WriteLine();
            }

            return true;
        }

        public Caixa ObterRegistro()
        {
            Console.Write("Digite a cor: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta: ");
            string etiqueta = Console.ReadLine();

            bool etiquetaJaUtilizada;

            do
            {
                etiquetaJaUtilizada = repositorioCaixa.EtiquetaJaUtilizada(etiqueta);

                if (etiquetaJaUtilizada)
                {
                    notificador.ApresentarMensagem("Etiqueta já utilizada, por gentileza informe outra", TipoMensagem.Erro);

                    Console.Write("Digite a etiqueta: ");
                    etiqueta = Console.ReadLine();
                }

            } while (etiquetaJaUtilizada);

            Caixa caixa = new Caixa(cor, etiqueta);

            return caixa;
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