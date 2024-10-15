using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.ORM;
using Biblioteca.Model;

namespace Biblioteca.Repositorio
{
    public class FuncionarioRepositorio
    {
        private BilbliotecaContext _context;

        public FuncionarioRepositorio(BilbliotecaContext context)
        {
            _context = context;
        }

        public void Add(Funcionario funcionario)
        {
            // Cria uma nova entidade do tipo TbFuncionario a partir do objeto Funcionario recebido
            var tbFuncionario = new TbFuncionario()
            {
                Nome = funcionario.Nome,
                Telefone = funcionario.Telefone,
                Email = funcionario.Email,
                Cargo = funcionario.Cargo
            };

            // Adiciona a entidade ao contexto
            _context.TbFuncionarios.Add(tbFuncionario);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbFuncionario = _context.TbFuncionarios.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbFuncionario != null)
            {
                // Remove a entidade do contexto
                _context.TbFuncionarios.Remove(tbFuncionario);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Funcionário não encontrado.");
            }
        }

        public List<Funcionario> GetAll()
        {
            // Converte as entidades do banco para objetos do tipo Funcionario
            var listFun = _context.TbFuncionarios
                .Select(item => new Funcionario
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Telefone = item.Telefone,
                    Email = item.Email,
                    Cargo = item.Cargo
                })
                .ToList();

            return listFun;
        }

        public Funcionario GetById(int id)
        {
            // Busca o Funcionario pelo ID no banco de dados
            var item = _context.TbFuncionarios.FirstOrDefault(c => c.Id == id);

            // Verifica se o Funcionario foi encontrado
            if (item == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }

            // Mapeia o objeto encontrado para a classe Funcionario
            return new Funcionario
            {
                Id = item.Id,
                Nome = item.Nome,
                Telefone = item.Telefone,
                Email = item.Email,
                Cargo = item.Cargo
            };
        }

        public void Update(Funcionario funcionario)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbFuncionario = _context.TbFuncionarios.FirstOrDefault(f => f.Id == funcionario.Id);

            // Verifica se a entidade foi encontrada
            if (tbFuncionario != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                tbFuncionario.Nome = funcionario.Nome;
                tbFuncionario.Telefone = funcionario.Telefone;
                tbFuncionario.Email = funcionario.Email;
                tbFuncionario.Cargo = funcionario.Cargo;

                // Atualiza as informações no contexto
                _context.TbFuncionarios.Update(tbFuncionario);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Funcionário não encontrado.");
            }
        }
    }
}
