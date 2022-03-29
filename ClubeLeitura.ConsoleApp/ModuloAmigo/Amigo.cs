using ClubeLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeLeitura.ConsoleApp
{
    public class Amigo
    {
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _nomeResponsavel;
        public string NomeResponsavel
        {
            get { return _nomeResponsavel; }
            set { _nomeResponsavel = value; }
        }

        private string _telefone;
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        private string _endereco;
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
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

        public bool TemEmprestimoEmAberto()
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

        private int ObtemPosicaoVazia()
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
