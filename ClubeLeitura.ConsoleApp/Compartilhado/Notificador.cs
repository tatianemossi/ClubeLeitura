using System;

namespace ClubeLeitura.ConsoleApp
{
    public class Notificador
    {
        public void ApresentarMensagem(string mensagem, TipoMensagem TipoMensagemEnum)
        {
            switch (TipoMensagemEnum)
            {
                case TipoMensagem.Sucesso: 
                    Console.ForegroundColor = ConsoleColor.Green; 
                    break;
                case TipoMensagem.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case TipoMensagem.Atencao:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                    default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
