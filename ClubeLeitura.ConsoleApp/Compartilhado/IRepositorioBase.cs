namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        public int contadorNumero;
        protected readonly T[] itens;

        public RepositorioBase (int qtdRegistros)
        {
            itens = new T[qtdRegistros];
        }

        public void Inserir(T item)
        {
            item.numero = ++contadorNumero;

            itens[ObterPosicaoVazia()] = item;
        }

        public void Editar(int numero, T item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i].numero == numero)
                {
                    item.numero = numero;
                    itens[i] = item;

                    break;
                }
            }
        }

        public void Excluir(int numero)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i].numero == numero)
                {
                    itens[i] = null;
                    break;
                }
            }
        }

        public T[] ObterTodosRegistros()
        {
            T[] itensInseridos = new T[ObterQuantidadeRegistros()];

            int j = 0;

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    itensInseridos[j] = itens[i];
                    j++;
                }
            }

            return itensInseridos;
        }

        public T ObterRegistro(int numero)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && numero == itens[i].numero)
                    return itens[i];
            }

           return null;
        }

        public bool ExisteNumeroRegistro(int numero)
        {
            bool numeroItemExiste = false;

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i].numero == numero)
                {
                    numeroItemExiste = true;
                    break;
                }
            }

            return numeroItemExiste;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int numeroItens = 0;

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                    numeroItens++;
            }

            return numeroItens;
        }

        public int ObterNumeroRegistro()
        {
            return ++contadorNumero;
        }
    }
}