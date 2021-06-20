using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using AeroAPI.Data;
using AeroAPI.Models;

namespace AeroAPI.Controllers
{
    /// <summary>
    /// Operações referentes ao Passageiro
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PassageiroController : ControllerBase
    {
        private readonly IRepository<Passageiro> passageiroRepository;

        public PassageiroController(IRepository<Passageiro> passageiroRepository)
        {
            this.passageiroRepository = passageiroRepository;
        }

        /// <summary>
        /// Obter dados de passageiro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public PassageiroModel Get(int id)
        {
            var passageiroEntity = passageiroRepository.Get(id);

            return new PassageiroModel
            {
                Id = passageiroEntity.Id,
                Celular = passageiroEntity.Celular,
                Idade = passageiroEntity.Idade,
                Nome = passageiroEntity.Nome
            };
        }

        /// <summary>
        /// Inserir dados de passageiro
        /// </summary>
        /// <param name="passageiro"></param>
        [HttpPost]
        public void Post([FromBody] PassageiroInputModel passageiro)
        {
            ValidateModel(passageiro);

            passageiroRepository.Insert(new Passageiro
            {
                Celular = passageiro.Celular,
                Idade = passageiro.Idade,
                Nome = passageiro.Nome
            });
        }


        /// <summary>
        /// Editar dados de passageiro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="passageiro"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PassageiroInputModel passageiro)
        {
            ValidateModel(passageiro);

            if (id == 0)
                throw new InvalidDataException("Invalid Id!");

            passageiroRepository.Update(new Passageiro
            {
                Id = id,
                Celular = passageiro.Celular,
                Idade = passageiro.Idade,
                Nome = passageiro.Nome
            });
        }

        /// <summary>
        /// Validação de dados.
        /// </summary>
        /// <param name="passageiro"></param>
        private void ValidateModel(PassageiroInputModel passageiro)
        {
            if (!TryValidateModel(passageiro, nameof(passageiro)))
                throw new InvalidDataException("Dados inválidos!");
        }

        /// <summary>
        /// Excluir dados de passageiro.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id == 0)
                throw new InvalidDataException("Invalid Id!");

            passageiroRepository.Delete(id);
        }
    }
}
