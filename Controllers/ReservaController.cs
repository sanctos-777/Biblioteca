using Bibiloteca.Model;
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
    public class ReservaController : ControllerBase
    {
        private readonly ReservaRepositorio _reservaRepo;

        public ReservaController(ReservaRepositorio reservaRepo)
        {
            _reservaRepo = reservaRepo;
        }

        // GET: api/<ReservaController>
        [HttpGet]
        public ActionResult<List<Reserva>> GetAll()
        {
            try
            {
                var reservas = _reservaRepo.GetAll();

                if (reservas == null || !reservas.Any())
                {
                    return NotFound(new { Mensagem = "Nenhuma reserva encontrada." });
                }

                var listaRes = reservas.Select(reserva => new Reserva
                {
                    Id = reserva.Id,
                    Fklivro = reserva.Fklivro,
                    Fkmembro = reserva.Fkmembro,
                    DataReserva = reserva.DataReserva
                }).ToList();

                return Ok(listaRes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar reservas.", Erro = ex.Message });
            }
        }

        // GET: api/Reserva/{id}
        [HttpGet("{id}")]
        public ActionResult<Reserva> GetById(int id)
        {
            try
            {
                var reserva = _reservaRepo.GetById(id);

                if (reserva == null)
                {
                    return NotFound(new { Mensagem = "Reserva não encontrada." });
                }

                var reservaId = new Reserva
                {
                    Id = reserva.Id,
                    Fklivro = reserva.Fklivro,
                    Fkmembro = reserva.Fkmembro,
                    DataReserva = reserva.DataReserva
                };

                return Ok(reservaId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao buscar reserva.", Erro = ex.Message });
            }
        }

        // POST api/<ReservaController>
        [HttpPost]
        public ActionResult<object> Post([FromForm] Reserva novoReserva)
        {
            try
            {
                var reserva = new Reserva
                {
                    Fklivro = novoReserva.Fklivro,
                    Fkmembro = novoReserva.Fkmembro,
                    DataReserva = novoReserva.DataReserva,
                };

                _reservaRepo.Add(reserva);

                var resultado = new
                {
                    Mensagem = "Reserva cadastrada com sucesso!",
                    Fklivro = reserva.Fklivro,
                    Fkmembro = reserva.Fkmembro,
                    DataReserva = reserva.DataReserva
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao cadastrar reserva.", Erro = ex.Message });
            }
        }

        // PUT api/<ReservaController>/5
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, [FromForm] Reserva reservaAtualizado)
        {
            try
            {
                var reservaExistente = _reservaRepo.GetById(id);

                if (reservaExistente == null)
                {
                    return NotFound(new { Mensagem = "Reserva não encontrada." });
                }

                reservaExistente.Fklivro = reservaAtualizado.Fklivro;
                reservaExistente.Fkmembro = reservaAtualizado.Fkmembro;
                reservaExistente.DataReserva = reservaAtualizado.DataReserva;

                _reservaRepo.Update(reservaExistente);

                var resultado = new
                {
                    Mensagem = "Reserva atualizada com sucesso!",
                    Fklivro = reservaExistente.Fklivro,
                    Fkmembro = reservaExistente.Fkmembro,
                    DataReserva = reservaExistente.DataReserva
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao atualizar reserva.", Erro = ex.Message });
            }
        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var reservaExistente = _reservaRepo.GetById(id);

                if (reservaExistente == null)
                {
                    return NotFound(new { Mensagem = "Reserva não encontrada." });
                }

                _reservaRepo.Delete(id);

                var resultado = new
                {
                    Mensagem = "Reserva excluída com sucesso!",
                    Fklivro = reservaExistente.Fklivro,
                    Fkmembro = reservaExistente.Fkmembro,
                    DataReserva = reservaExistente.DataReserva
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = "Erro ao excluir reserva.", Erro = ex.Message });
            }
        }
    }
}
