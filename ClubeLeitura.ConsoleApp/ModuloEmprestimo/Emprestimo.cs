using System;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo
    {
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private Amigo _amigo;
        public Amigo Amigo
        {
            get { return _amigo; }
            set { _amigo = value; }
        }

        private Revista _revista;
        public Revista Revista
        {
            get { return _revista; }
            set { _revista = value; }
        }

        private DateTime _dataEmprestimo;
        public DateTime DataEmprestimo
        {
            get { return _dataEmprestimo; }
            set { _dataEmprestimo = value; }
        }

        private DateTime _dataDevolucao;
        public DateTime DataDevolucao
        {
            get { return _dataDevolucao; }
            set { _dataDevolucao = value; }
        }

        private bool _estaAberto;
        public bool EstaAberto
        {
            get { return _estaAberto; }
            set { _estaAberto = value; }
        }

        public void Fechar(DateTime data)
        {
            if (_estaAberto)
            {
                _estaAberto = false;
                _dataDevolucao = data;
            }
        }
    }
}
