
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Biblioteca.Model;
using Biblioteca.ORM;

namespace Biblioteca.Repositorio
{
    public class CategoriaRepositorio
    {
        private BilbliotecaContext _context;

        public CategoriaRepositorio(BilbliotecaContext context)
        {
            _context = context;
        }

        public void Add(Categoria categoria, IFormFile? documento)
        {
            byte[] categoriaBytes = null;

            // Verifica se uma foto foi enviada
            if (documento != null && documento.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    documento.CopyTo(memoryStream);
                    categoriaBytes = memoryStream.ToArray();
                }
            }

            // Cria uma nova entidade do tipo TbCategoria
            TbCategoria tbCategoria = new TbCategoria()
            {
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
                
            };

            // Adiciona a entidade ao contexto
            _context.TbCategorias.Add(tbCategoria);
            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbCategoria = _context.TbCategorias.FirstOrDefault(c => c.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbCategoria != null)
            {
                // Remove a entidade do contexto
                _context.TbCategorias.Remove(tbCategoria);
                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Categoria não encontrada.");
            }
        }

        public List<Categoria> GetAll()
        {
            List<Categoria> listCat = new List<Categoria>();

            var listTb = _context.TbCategorias.ToList();

            foreach (var item in listTb)
            {
                var categoria = new Categoria
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Descricao = item.Descricao
                };

                listCat.Add(categoria);
            }

            return listCat;
        }

        public Categoria GetById(int id)
        {
            // Busca a categoria pelo ID no banco de dados
            var item = _context.TbCategorias.FirstOrDefault(c => c.Id == id);

            // Verifica se a categoria foi encontrada
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Categoria
            var categoria = new Categoria
            {
                Id = item.Id,
                Nome = item.Nome,
                Descricao = item.Descricao,
              
            };

            return categoria; // Retorna a categoria encontrada
        }

        public void Update(Categoria categoria, IFormFile? documento)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbCategoria = _context.TbCategorias.FirstOrDefault(c => c.Id == categoria.Id);

            // Verifica se a entidade foi encontrada
            if (tbCategoria != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Categoria recebido
                tbCategoria.Nome = categoria.Nome;
                tbCategoria.Descricao = categoria.Descricao;

                // Verifica se um novo documento foi enviado
                if (documento != null && documento.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        documento.CopyTo(memoryStream);
                        
                    }
                }

                // Atualiza as informações no contexto
                _context.TbCategorias.Update(tbCategoria);
                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Categoria não encontrada.");
            }
        }
    }
}
