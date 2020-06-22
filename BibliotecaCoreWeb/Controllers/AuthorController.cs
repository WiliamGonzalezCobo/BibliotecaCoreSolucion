using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaCore.Dal.Entities;
using BibliotecaCore.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BibliotecaCore.WebApi.Controllers { 

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        /// <summary>
        /// lista todos los autores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            try
            {
                return _authorService.GetAuthors();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return default;
            }

        }

        /// <summary>
        /// crea una nueva categoria
        /// </summary>
        /// <param name="Author"></param>
        [HttpPost]
        public void Post([FromBody] Author Author)
        {
            try
            {
                _authorService.Add(Author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }

        /// <summary>
        /// actualiza una categoria por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Author"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author author)
        {
            try
            {
                _authorService.Update(author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// elimina una categoria
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _authorService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
