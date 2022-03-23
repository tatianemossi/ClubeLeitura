namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo
    {
        public Amigo[] amigos;
        public int idAmigo;

        public void Inserir(Amigo amigo)
        {
            amigo.idAmigo = ++idAmigo;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;
        }

        public void Editar(int numeroSelecionado, Amigo amigo)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].idAmigo == numeroSelecionado)
                {
                    amigo.idAmigo = numeroSelecionado;
                    amigos[i] = amigo;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].idAmigo == numeroSelecionado)
                {
                    amigos[i] = null;
                    break;
                }
            }
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

        public Amigo[] SelecionarTodos()
        {
            int quantidadeAmigos = ObterQtdAmigos();

            Amigo[] amigosInseridos = new Amigo[quantidadeAmigos];

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

        public int ObterQtdAmigos()
        {
            int idAmigo = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                    idAmigo++;
            }

            return idAmigo;
        }

        public bool VerificarIdAmigoExiste(int idAmigo)
        {
            bool idAmigoEncontrado = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].idAmigo == idAmigo)
                {
                    idAmigoEncontrado = true;
                    break;
                }
            }
            return idAmigoEncontrado;
        }
    }
}
