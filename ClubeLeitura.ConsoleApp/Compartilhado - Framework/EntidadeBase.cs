namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int numero;

        public abstract ResultadoValidacao Validar();
    }
}
