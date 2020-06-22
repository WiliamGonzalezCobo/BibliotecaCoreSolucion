using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaCore.Dal.Entities;
using BibliotecaCore.Service.Interface;
using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BibliotecaCore.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger) {
            _bookService = bookService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los libros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            try
            {
                return _bookService.GetBooks();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return default;
            }
            
        }

        /// <summary>
        /// obtiene un libro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBook")]
        public Book Get(int id)
        {
            try
            {
                return _bookService.GetBook(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return default;
            }
            
        }

        /// <summary>
        /// Guarda un libro
        /// </summary>
        /// <param name="book"></param>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            try
            {
                _bookService.Add(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            
        }

        /// <summary>
        /// Actualiza un libro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            try
            {
                _bookService.Update(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }

        /// <summary>
        /// Elimina un libro
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _bookService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            
        }
    }
}
