﻿namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista
    {
        public Revista[] revistas; 
        public int numeroRevista;

        public string Inserir(Revista revista)
        {
            string validacao = revista.Validar();

            if (validacao != "REGISTRO_VALIDO")
                return validacao;

            revista.Numero = ++numeroRevista;

            int posicaoVazia = ObterPosicaoVazia();

            revistas[posicaoVazia] = revista;

            return validacao;
        }

        public void Editar(int numeroSelecionado, Revista revista)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i].Numero == numeroSelecionado)
                {
                    revista.Numero = numeroSelecionado;
                    revistas[i] = revista;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i].Numero == numeroSelecionado)
                {
                    revistas[i] = null;
                    break;
                }
            }
        }

        public Revista[] SelecionarTodos()
        {
            int quantidadeRevistas = ObterQtdRevistas();

            Revista[] revistasInseridas = new Revista[quantidadeRevistas];

            int j = 0;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                {
                    revistasInseridas[j] = revistas[i];
                    j++;
                }
            }

            return revistasInseridas;
        }

        public Revista SelecionarRevista(int numeroRevista)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null && numeroRevista == revistas[i].Numero)
                    return revistas[i];
            }

            return null;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                    return i;
            }

            return -1;
        }

        public bool VerificarNumeroRevistaExiste(int numeroRevista)
        {
            bool numeroRevistaEncontrado = false;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null && revistas[i].Numero == numeroRevista)
                {
                    numeroRevistaEncontrado = true;
                    break;
                }
            }

            return numeroRevistaEncontrado;
        }

        public int ObterQtdRevistas()
        {
            int numeroRevistas = 0;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                    numeroRevistas++;
            }

            return numeroRevistas;
        }
    }
}
