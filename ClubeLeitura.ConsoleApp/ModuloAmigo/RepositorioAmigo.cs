using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo : IRepositorio<Amigo>
    {
        private int numeroAmigo;
        private readonly Amigo[] amigos;

        public RepositorioAmigo(int qtdAmigos)
        {
            amigos = new Amigo[qtdAmigos];
        }

        public void Inserir(Amigo amigo)
        {
            amigo.numero = ++numeroAmigo;

            amigos[ObterPosicaoVazia()] = amigo;
        }

        public void Editar(int numeroSelecionado, Amigo amigo)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].numero == numeroSelecionado)
                {
                    amigo.numero = numeroSelecionado;
                    amigos[i] = amigo;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].numero == numeroSelecionado)
                {
                    amigos[i] = null;
                    break;
                }
            }
        }

        public Amigo[] ObterTodosRegistros()
        {
            Amigo[] amigosInseridos = new Amigo[ObterQuantidadeRegistros()];

            int j = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    amigosInseridos[j] = amigos[i];
                    j++;
                }
            }

            return amigosInseridos;
        }

        public Amigo ObterRegistro(int numero)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && numeroAmigo == amigos[i].numero)
                    return amigos[i];
            }

            return null;
        }

        public bool ExisteNumeroRegistro(int numero)
        {
            bool numeroAmigoExiste = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].numero == numeroAmigo)
                {
                    numeroAmigoExiste = true;
                    break;
                }
            }

            return numeroAmigoExiste;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int numeroAmigos = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                    numeroAmigos++;
            }

            return numeroAmigos;
        }

        public int ObterNumeroRegistro()
        {
            return ++numeroAmigo;
        }

        #region Métodos Específicos da Classe
        public Amigo[] SelecionarAmigosComMulta()
        {
            Amigo[] amigosComMulta = new Amigo[ObterQtdAmigosComMulta()];

            int j = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].TemMultaEmAberto())
                {
                    amigosComMulta[j] = amigos[i];
                    j++;
                }
            }

            return amigosComMulta;
        }

        public int ObterQtdAmigosComMulta()
        {
            int numeroAmigos = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].TemMultaEmAberto())
                    numeroAmigos++;
            }

            return numeroAmigos;
        }
        #endregion
    }
}
