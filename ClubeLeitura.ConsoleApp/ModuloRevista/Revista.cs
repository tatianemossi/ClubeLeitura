using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using System;

namespace ClubeLeitura.ConsoleApp
{
    public class Revista
    {
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _colecao;
        public string Colecao
        {
            get { return _colecao; }
            set { _colecao = value; }
        }

        private int _edicao;
        public int Edicao
        {
            get { return _edicao; }
            set { _edicao = value; }
        }

        private int _ano;
        public int Ano
        {
            get { return _ano; }
            set { _ano = value; }
        } 

        private Caixa _caixa;
        public Caixa Caixa
        {
            get { return _caixa; }
            set { _caixa = value; }
        }

        private Emprestimo[] _historicoEmprestimos = new Emprestimo[10];
        public Emprestimo[] HistoricoEmprestimos
        {
            get { return _historicoEmprestimos; }
            set { _historicoEmprestimos = value; }
        }


        public void RegistrarEmprestimo(Emprestimo emprestimo)
        {
            _historicoEmprestimos[ObtemPosicaoVazia()] = emprestimo;
        }

        public bool EstaEmprestada()
        {
            bool temEmprestimoEmAberto = false;

            foreach (Emprestimo emprestimo in _historicoEmprestimos)
            {
                if (emprestimo != null && emprestimo.EstaAberto)
                {
                    temEmprestimoEmAberto = true;
                    break;
                }
            }
            return temEmprestimoEmAberto;
        }

        public string Validar()
        {
            string validacao = "";

            if (string.IsNullOrEmpty(_colecao))
                validacao += "É necessário incluir uma coleção!\n";

            if (_edicao < 0)
                validacao += "A edição de uma revista não pode ser menor que zero!\n";

            if (_ano < 0 || _ano > DateTime.Now.Year)
                validacao += "O ano da revista precisa ser válido!\n";

            if (string.IsNullOrEmpty(validacao))
                return "REGISTRO_VALIDO";

            return validacao;
        }

        public int ObtemPosicaoVazia()
        {
            for (int i = 0; i < _historicoEmprestimos.Length; i++)
            {
                if (_historicoEmprestimos[i] == null)
                    return i;
            }

            return -1;
        }
    }
}