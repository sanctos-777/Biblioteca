using System.Text.Json.Serialization;

namespace Biblioteca.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Length { get; internal set; }
        public string Nome { get; internal set; }

        internal void CopyTo(MemoryStream memoryStream)
        {
            throw new NotImplementedException();
        }
    }
}
