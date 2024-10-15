namespace Biblioteca.Model
{
    public class EmprestimoDto
    {
        public int Id { get; set; }
        public string DataEmprestimo { get; set; }
        public string DataDevolucao { get; set; }
        public int FKMembro { get; set; }
        public int FKLivro { get; set; }
    }
}
