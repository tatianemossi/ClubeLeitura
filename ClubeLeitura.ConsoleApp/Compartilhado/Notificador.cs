using System;

namespace ClubeLeitura.ConsoleApp
{
    public class Notificador
    {
        public void ApresentarMensagem(string mensagem, TipoMensagemEnum TipoMensagemEnum)
        {
            switch (TipoMensagemEnum)
            {
                case TipoMensagemEnum.Sucesso: 
                    Console.ForegroundColor = ConsoleColor.Green; 
                    break;
                case TipoMensagemEnum.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case TipoMensagemEnum.Atencao:
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
