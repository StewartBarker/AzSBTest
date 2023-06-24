namespace ContosoPizza.Models;

public class Pizza : IPizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }
    public PizzaType Type { get; set; }

    // {
    //     PizzaId = Guid.NewGuid();
    // }
}