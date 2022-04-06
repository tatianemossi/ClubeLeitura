using ClubeLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo : RepositorioBase
    {
        public RepositorioAmigo(int qtdAmigos) : base(qtdAmigos)
        {
        }

        public List<Amigo> SelecionarAmigosComMulta()
        {
            List<Amigo> amigosComMulta = new List<Amigo>();

            foreach (Amigo amigo in registros)
                if (amigo.TemMultaEmAberto())
                    amigosComMulta.Add(amigo);

            return amigosComMulta;
        }        
    }
}
