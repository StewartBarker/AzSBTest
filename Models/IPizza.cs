namespace ContosoPizza.Models;

public interface IPizza
{
    int Id { get; }
    string? Name { get; set; }
    bool IsGlutenFree { get; set; }
    PizzaType Type { get; set; }
}