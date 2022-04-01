using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloCategoria
{
    public class RepositorioCategoria : RepositorioBase<Categoria>
    {
        private readonly Categoria[] categorias;

        public RepositorioCategoria(int qtdCategorias) : base(qtdCategorias)
        {
            categorias = new Categoria[qtdCategorias];
        }       
    }
}
