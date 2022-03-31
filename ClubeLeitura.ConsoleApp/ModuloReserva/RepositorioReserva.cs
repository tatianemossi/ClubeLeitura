using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloReserva
{
    public class RepositorioReserva : IRepositorio<Reserva>
    {
        private readonly Reserva[] reservas;
        private int numeroReserva;

        public RepositorioReserva(int qtdReservas)
        {
            reservas = new Reserva[qtdReservas];
        }

        public void Inserir(Reserva reserva)
        {
            reserva.numero = ++numeroReserva;

            reserva.Abrir();
            reserva.revista.RegistrarReserva(reserva);
            reserva.amigo.RegistrarReserva(reserva);

            reservas[ObterPosicaoVazia()] = reserva;
        }

        public void Editar(int numero, Reserva item)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(int numero)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].numero == numero)
                {
                    reservas[i] = null;
                    break;
                }
            }
        }

        public Reserva[] ObterTodosRegistros()
        {
            Reserva[] reservasInseridas = new Reserva[ObterQuantidadeRegistros()];

            int j = 0;

            for (int i = 0; i < reservasInseridas.Length; i++)
            {
                if (reservas[i] != null)
                {
                    reservasInseridas[j] = reservas[i];
                    j++;
                }
            }

            return reservasInseridas;
        }

        public Reserva ObterRegistro(int numero)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && numeroReserva == reservas[i].numero)
                    return reservas[i];
            }

            return null;
        }

        public int ObterQuantidadeRegistros()
        {
            int numeroReservas = 0;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null)
                    numeroReservas++;
            }

            return numeroReservas;
        }

        public bool ExisteNumeroRegistro(int numero)
        {
            bool numeroReservaExiste = false;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].numero == numeroReserva)
                {
                    numeroReservaExiste = true;
                    break;
                }
            }

            return numeroReservaExiste;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterNumeroRegistro()
        {
            return ++numeroReserva;
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
