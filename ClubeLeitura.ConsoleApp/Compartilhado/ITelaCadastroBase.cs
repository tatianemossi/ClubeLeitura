namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public interface ITelaCadastroBase<T> where T : EntidadeBase
    {
        string MostrarOpcoes();

        void Inserir();      

        bool Visualizar(string tipo);

        T ObterRegistro();

        int ObterNumeroRegistro();

        void MostrarTitulo(string titulo);
    }
}
