namespace Biblioteca.Model
{
    public class EmprestimoDto
    {
        public int Id { get; set; }
        public string DataEmprestimo { get; set; }
        public string DataDevolucao { get; set; }
        public int FKMembro { get; set; }
        public int Fkmembro { get; internal set; }
        public object FkMembro { get; internal set; }
        public int FKLivro { get; set; }
        public int Fklivro { get; internal set; }
        public object FkLivro { get; internal set; }
    }
}
