using Biblioteca.ORM;
using Biblioteca.Model;

namespace BibliotecaWebAPI.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly BilbliotecaContext _context;

        public UsuarioRepositorio(BilbliotecaContext context)
        {
            _context = context;
        }

        public TbUsuario GetByCredentials(string usuario, string senha)
        {
            // Aqui você deve usar a lógica de hash para comparar a senha
            return _context.TbUsuarios.FirstOrDefault(u => u.Usuario == usuario && u.Senha == senha);
        }

        internal TbUsuario GetByCredentials(object usuario, string senha)
        {
            throw new NotImplementedException();
        }

        // Você pode adicionar métodos adicionais para gerenciar usuários
    }
}
