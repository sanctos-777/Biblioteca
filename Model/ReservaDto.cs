namespace Bibiloteca.Model
{
    public class Reserva
    {
        public int Id { get; set; }

        public string DataReserva { get; set; }

        public int Fkmembro { get; set; }

        public int Fklivro { get; set; }
    }
}
