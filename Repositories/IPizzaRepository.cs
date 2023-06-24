using ContosoPizza.Models;

namespace ContosoPizza.Repositories;

public interface IPizzaRepository
{
        List<Pizza> GetAll();
        
        Pizza? GetPizza(int pizzaId);
        void AddPizza(Pizza pizza);
        bool UpdatePizza(Pizza pizza);
        bool DeletePizza(Pizza pizza);
}