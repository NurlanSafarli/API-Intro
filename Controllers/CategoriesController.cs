﻿
using ApiAB202.Repositories.Interfaces;
using ApiAB202.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAB202.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {

            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> Get(int id)
        {

            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            return (Ok(), await _service.GetAsync(id));

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto categoryDto)
        {


            await _service.Create(categoryDto);

            return StatusCode(StatusCodes.Status201Created);

        }
        [HttpPut("{Id}")]

        public async Task<IActionResult> Update(int id, string name)
        {

            if (id <= 0) return BadRequest();
            await _service.UpdateAsync(id, name);

            return NoContent();

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int Id)
        {

            if (Id <= 0) return BadRequest();
            await _service.DeleteAsync(Id);
            return NoContent();

        }

    }
}
