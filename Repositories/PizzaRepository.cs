using ContosoPizza.Models;

namespace ContosoPizza.Repositories;

public class PizzaRepository : IPizzaRepository
{
    private List<Pizza> Pizzas { get; set; }
    
    public PizzaRepository()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }
    
    public List<Pizza> GetAll() => Pizzas;

    public Pizza? GetPizza(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public void AddPizza(Pizza pizza)
    {
        pizza.Id = Pizzas.Max(p => p.Id);
        pizza.Id++;
        Pizzas.Add(pizza);
    }

    public bool UpdatePizza(Pizza pizza)
    {
        var foundPizza = Pizzas.Find(p => p.Id == pizza.Id);
        if (foundPizza is null)
            return false;

        foundPizza.Type = pizza.Type;
        foundPizza.Name = pizza.Name;
        foundPizza.IsGlutenFree = pizza.IsGlutenFree;
        return true;
    }

    public bool DeletePizza(Pizza pizza)
    {
        var foundPizza = Pizzas.Find(p => p.Id == pizza.Id);
        if (foundPizza is null)
            return false;

        Pizzas.Remove(foundPizza);
        return true;
    }
}