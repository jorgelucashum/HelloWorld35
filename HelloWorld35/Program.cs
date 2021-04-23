using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HelloWorld35.Entities;
using HelloWorld35.Entities.Exceptions;

namespace HelloWorld35
{
    class Program
    {
        static void Main(string[] args)
        {
            try // Executando o código até que haja uma exceção.
            {
                Console.Write("Número do quarto: ");
                int roomN = int.Parse(Console.ReadLine());
                Console.Write("Data do check-in (dd/mm/aaaa): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Data do check-out (dd/mm/aaaa): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(roomN, checkIn, checkOut);

                Console.WriteLine("\nReserva: " + reservation + "\n");

                Console.Write("Atualizar check-in (dd/mm/aaaa): ");
                DateTime attCheckIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Atualizar check-out (dd/mm/aaaa): ");
                DateTime attCheckOut = DateTime.Parse(Console.ReadLine());
                reservation.UpdateDates(attCheckIn, attCheckOut);

                Console.WriteLine("\nReserva: " + reservation);
            }
            catch (DomainException e) // Capturando exceção personalizada 'DomainException'.
            {
                Console.WriteLine("Erro na reserva: " + e.Message);
            }
            catch(FormatException e) // 'FormatException' Exceção para capturar formatos não aceitos na entrada.
            {
                Console.WriteLine("Erro no formato: " + e.Message);
            }
            catch(Exception e) // 'Exception' tipo mais genérico de exceção para tratar as que não foram previstas.
            {
                Console.WriteLine("Erro inesperado" + e.Message);
            }
        }
    }
}
