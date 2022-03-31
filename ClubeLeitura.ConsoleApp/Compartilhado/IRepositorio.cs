namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        void Inserir(T item);

        void Editar(int numero, T item);

        T[] ObterTodosRegistros();

        void Excluir(int numero);

        T ObterRegistro(int numero);

        bool ExisteNumeroRegistro(int numero);

        int ObterPosicaoVazia();

        int ObterQuantidadeRegistros();

        int ObterNumeroRegistro();
    }
}