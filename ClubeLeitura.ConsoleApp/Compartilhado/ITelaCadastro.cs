namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public interface ITelaCadastro<T> where T : EntidadeBase
    {
        string MostrarOpcoes();

        void Inserir();

        void Editar();

        void Excluir();

        bool Visualizar(string tipo);

        T ObterRegistro();

        int ObterNumeroRegistro();

        void MostrarTitulo(string titulo);
    }
}
