using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo : RepositorioBase<Amigo>
    {
        public Amigo[] amigos;

        public RepositorioAmigo(int quantidade)
        {
            itens = new Amigo[quantidade];
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
