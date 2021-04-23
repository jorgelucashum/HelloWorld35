using System;

using HelloWorld35.Entities.Exceptions;


namespace HelloWorld35.Entities
{
    // 'throw' Lança a exceção / "corta" o método, assim como 'return'.
    // O modelo de tratamento de exceções permite que erros sejam tratados de forma consistente e flexível, usando boas práticas.
    // - Lógica delegada
    // - Construtores podem ter exceções
    // - Código mais simples. Não há aninhamento de condicionais: a qualquer momento que uma exceção for disparada, a execução é interrompida e cai no block catch correspondente.
    // -É possível capturar inclusive outras exceções de sistema.
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation()
        {
        }
        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("O check-out deve ser feito em uma data posterior ao check-in"); // 'throw' lança a exceção personalizada.
            }
        
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration() // Método para retornar o tempo de hospedagem.
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn); // 'TimeSpan' classe com métodos de tempo.
            return (int)duration.TotalDays; // Método para retornar os dias, usando casting '(int)' porque o '.TotalDays' é do tipo double.
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if(checkIn < now || checkOut < now)
            {
                throw new DomainException("Datas de reservas devem ser atualizadas para datas futuras"); // 'throw' lança a exceção personalizada.
            }
            if (checkOut <= checkIn)
            {
                throw new DomainException("O check-out deve ser feito em uma data posterior ao check-in");
            }
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString()
        {
            return $"Quarto: {RoomNumber}, Check-in: {CheckIn.ToString("dd/MM/yyyy")}, Check-out: {CheckOut.ToString("dd/MM/yyyy")}, Total de noites: {Duration()}.";
        }
    }
}
