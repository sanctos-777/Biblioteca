﻿using Biblioteca.Model;
using Biblioteca.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepositorio _livroRepo;

        public LivroController(LivroRepositorio livroRepo)
        {
            _livroRepo = livroRepo;
        }

        // GET: api/<LivroController>
        [HttpGet]
        public ActionResult<List<Livro>> GetAll()
        {
            try
            {
                var livros = _livroRepo.GetAll();

                if (livros == null || !livros.Any())
                {
                    return NotFound(new { Mensagem = "Nenhum livro encontrado." });
                }

                var listaLiv = livros.Select(livro => new Livro
                {
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    FkCategoria = livro.FkCategoria,
                    Disponibilidade = livro.Disponibilidade
                }).ToList();

                return Ok(listaLiv);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar livros.", Erro = ex.Message });
            }
        }

        // GET: api/Livro/{id}
        [HttpGet("{id}")]
        public ActionResult<Livro> GetById(int id)
        {
            try
            {
                var livro = _livroRepo.GetById(id);

                if (livro == null)
                {
                    return NotFound(new { Mensagem = "Livro não encontrado." });
                }

                var livroId = new Livro
                {
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    FkCategoria = livro.FkCategoria,
                    Disponibilidade = livro.Disponibilidade
                };

                return Ok(livroId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar livro.", Erro = ex.Message });
            }
        }

        // POST api/<LivroController>
        [HttpPost]
        public ActionResult<object> Post([FromForm] LivroDto novoLivro)
        {
            try
            {
                var livro = new Livro
                {
                    Titulo = novoLivro.Titulo,
                    Autor = novoLivro.Autor,
                    AnoPublicacao = novoLivro.AnoPublicacao,
                    FkCategoria = novoLivro.FkCategoria,
                    Disponibilidade = novoLivro.Disponibilidade
                };

                _livroRepo.Add(livro);

                var resultado = new
                {
                    Mensagem = "Livro cadastrado com sucesso!",
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    AnoPublicacao = livro.AnoPublicacao,
                    FkCategoria = livro.FkCategoria,
                    Disponibilidade = livro.Disponibilidade
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao cadastrar livro.", Erro = ex.Message });
            }
        }

        // PUT api/<LivroController>/5
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, [FromForm] LivroDto livroAtualizado)
        {
            try
            {
                var livroExistente = _livroRepo.GetById(id);

                if (livroExistente == null)
                {
                    return NotFound(new { Mensagem = "Livro não encontrado." });
                }

                livroExistente.Titulo = livroAtualizado.Titulo;
                livroExistente.Autor = livroAtualizado.Autor;
                livroExistente.AnoPublicacao = livroAtualizado.AnoPublicacao;
                livroExistente.FkCategoria = livroAtualizado.FkCategoria;
                livroExistente.Disponibilidade = livroAtualizado.Disponibilidade;

                _livroRepo.Update(livroExistente);

                var resultado = new
                {
                    Mensagem = "Livro atualizado com sucesso!",
                    Titulo = livroExistente.Titulo,
                    Autor = livroExistente.Autor,
                    AnoPublicacao = livroExistente.AnoPublicacao,
                    FkCategoria = livroExistente.FkCategoria,
                    Disponibilidade = livroExistente.Disponibilidade
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao atualizar livro.", Erro = ex.Message });
            }
        }

        // DELETE api/<LivroController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var livroExistente = _livroRepo.GetById(id);

                if (livroExistente == null)
                {
                    return NotFound(new { Mensagem = "Livro não encontrado." });
                }

                _livroRepo.Delete(id);

                var resultado = new
                {
                    Mensagem = "Livro excluído com sucesso!",
                    Titulo = livroExistente.Titulo,
                    Autor = livroExistente.Autor,
                    AnoPublicacao = livroExistente.AnoPublicacao,
                    FkCategoria = livroExistente.FkCategoria,
                    Disponibilidade = livroExistente.Disponibilidade
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao excluir livro.", Erro = ex.Message });
            }
        }
    }
}
