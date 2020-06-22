using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaCore.Dal.Entities;
using BibliotecaCore.Service.Implementation;
using BibliotecaCore.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BibliotecaCore.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger) {
            _categoryService = categoryService;
            _logger = logger;
        }

        /// <summary>
        /// lista todas las categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            try
            {
                return _categoryService.GetCategories();
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
        /// <param name="category"></param>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            try
            {
                _categoryService.Add(category);
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
        /// <param name="category"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            try
            {
                _categoryService.Update(category);
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
                _categoryService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
