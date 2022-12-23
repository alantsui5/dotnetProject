using RazorPagesPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesPizza.Services;
public class PizzaService
{

    private readonly PizzaDb _db;
    
    static int nextId = 3;
    public PizzaService(PizzaDb db)
    {
        _db = db;
        
        if (!_db.Pizzas.Any()){
            _db.Pizzas.Add(new Pizza {Name = "Classic Italian", Price=20.00M, Size=PizzaSize.Large, IsGlutenFree = false });
            _db.Pizzas.Add(new Pizza {Name = "Veggie", Price=15.00M, Size=PizzaSize.Small, IsGlutenFree = true });
            _db.SaveChanges();
        }
    }
    

    public List<Pizza> GetAll() => _db.Pizzas.AsNoTracking().ToList();

    public Pizza? Get(int id) => _db.Pizzas.AsNoTracking().FirstOrDefault(p => p.Id == id);

    public void Add(Pizza newPizza)
    {
        newPizza.Id = nextId++;

        _db.Pizzas.Add(newPizza);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is not null){
            _db.Pizzas.Remove(pizza);
            _db.SaveChanges();
        }
    }

    public void Update(Pizza pizza)
    {
        var pizzaToUpdate = _db.Pizzas.Find(pizza.Id);
        if (pizzaToUpdate is null)
            throw new InvalidOperationException("Pizza does not exist");

        pizzaToUpdate.IsGlutenFree = pizza.IsGlutenFree;
        pizzaToUpdate.Name = pizza.Name;
        pizzaToUpdate.Price = pizza.Price;
        pizzaToUpdate.Size = pizza.Size;

        _db.SaveChanges();
    }
}