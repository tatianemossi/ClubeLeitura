namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        public void Inserir(T item);

        public void Editar(int numero, T item);

        public T[] ObterTodosRegistros();

        public void Excluir(int numero);

        public T ObterRegistro(int numero);

        public bool ExisteNumeroRegistro(int numero);

        public int ObterPosicaoVazia();

        public int ObterQuantidadeRegistros();

        public int ObterNumeroRegistro();
    }
}