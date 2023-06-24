using System.Net;
using ContosoPizza.Models;
using ContosoPizza.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly ILogger<PizzaController> _logger;
    private readonly IPizzaRepository _pizzaRepository;

    public PizzaController(ILogger<PizzaController> logger, IPizzaRepository pizzaRepository)
    {
        _logger = logger;
        _pizzaRepository = pizzaRepository;
    }

    [HttpGet]
    public ActionResult<IList<Pizza>> GetAll() => _pizzaRepository.GetAll();

    [HttpGet("{id}")]
    public ActionResult<IPizza> Get(int id)
    {
        var pizza = _pizzaRepository.GetPizza(id);
        if (pizza is null)
            return NotFound();
        return (Pizza)pizza;
    }

    [HttpPost]
    public ActionResult Create(Pizza pizza)
    {
        _pizzaRepository.AddPizza(pizza);
        
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Pizza pizzaToUpdate)
    {
        if (id != pizzaToUpdate.Id)
            return BadRequest();
        
        var pizza = _pizzaRepository.GetPizza(id);
        if (pizza is null)
            return NotFound();

        _pizzaRepository.UpdatePizza(pizzaToUpdate);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizzaToDelete = _pizzaRepository.GetPizza(id);
        if (pizzaToDelete is null)
            return NotFound();

        _pizzaRepository.DeletePizza(pizzaToDelete);
        return NoContent();
    }
}