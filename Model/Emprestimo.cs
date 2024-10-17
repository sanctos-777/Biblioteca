namespace Biblioteca.Model
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public string DataEmprestimo { get; set; }
        public string DataDevolucao { get; set; }
        public int Fkmembro { get; set; }
        public object FkMembro { get; internal set; }
        public int Fklivro { get; set; }
        public object FkLivro { get; internal set; }
    }
}
