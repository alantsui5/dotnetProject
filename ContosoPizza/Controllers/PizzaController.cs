using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaDb _db;
    public PizzaController(PizzaDb db) 
    {
        _db = db;
    }

    // GET all action
    [HttpGet]
    public async Task<ActionResult<List<Pizza>>> GetAll(){
        return await _db.Pizzas.ToListAsync();
    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<ActionResult<Pizza>> Get(int id)
    {
        var pizza = await _db.Pizzas.FindAsync(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    // POST action
    [HttpPost]
    public async Task<IActionResult> Create(Pizza pizza)
    {            
        // This code will save the pizza and return a result
        await _db.Pizzas.AddAsync(pizza);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pizza pizza)
    {
        // This code will update the pizza and return a result
        if(id != pizza.Id)
            return BadRequest();

        var existingPizza = await _db.Pizzas.FindAsync(id);
        if(existingPizza is null)
            return NotFound();

        existingPizza.Name = pizza.Name;
        existingPizza.IsGlutenFree = pizza.IsGlutenFree;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // This code will delete the pizza and return a result
        var pizza = await _db.Pizzas.FindAsync(id);
   
        if (pizza is null)
            return NotFound();
        
        _db.Pizzas.Remove(pizza);
        await _db.SaveChangesAsync();
        return Ok();
    }
}