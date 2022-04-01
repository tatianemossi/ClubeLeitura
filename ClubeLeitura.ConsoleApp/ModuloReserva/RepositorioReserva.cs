using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloReserva
{
    public class RepositorioReserva : RepositorioBase<Reserva>
    {
        private readonly Reserva[] reservas;

        public RepositorioReserva(int qtdReservas)
        {
            reservas = new Reserva[qtdReservas];
        }        

        #region Métodos Específicos da Classe
        public int ObterQtdReservasEmAberto()
        {
            int numeroReservas = 0;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].estaAberta)
                    numeroReservas++;
            }

            return numeroReservas;
        }

        public Reserva[] SelecionarReservasEmAberto()
        {
            Reserva[] reservasInseridas = new Reserva[ObterQtdReservasEmAberto()];

            int j = 0;

            for (int i = 0; i < reservasInseridas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].estaAberta)
                {
                    reservasInseridas[j] = reservas[i];
                    j++;
                }
            }

            return reservasInseridas;
        }
        #endregion
    }
}
