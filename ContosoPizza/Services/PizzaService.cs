using ContosoPizza.Models;
using ContosoPizza.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PizzaService
{
    private readonly PizzaDb _db;

    public PizzaService(PizzaDb db)
    {
        _db = db;
    }

    public IEnumerable<Pizza> GetAll()
    {
        return _db.Pizzas
            .AsNoTracking()
            .ToList();
    }

    public Pizza? GetById(int id)
    {
        return _db.Pizzas
            .Include(p => p.Toppings)
            .Include(p => p.Sauce)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public Pizza Create(Pizza newPizza)
    {
        _db.Pizzas.Add(newPizza);
        _db.SaveChanges();

        return newPizza;
    }

    public IEnumerable<Sauce> GetAllSauces()
    {
        return _db.Sauces.AsNoTracking().ToList();
    }


    public void UpdateSauce(int pizzaId, int sauceId)
    {
        var pizzaToUpdate = _db.Pizzas.Find(pizzaId);
        var sauceToUpdate = _db.Sauces.Find(sauceId);

        if (pizzaToUpdate is null || sauceToUpdate is null)
        {
            throw new InvalidOperationException("Pizza or sauce does not exist");
        }

        pizzaToUpdate.Sauce = sauceToUpdate;

        _db.SaveChanges();
    }

    public IEnumerable<Topping> GetAllToppings()
    {
        return _db.Toppings.AsNoTracking().ToList();
    }

    public void AddTopping(int pizzaId, int toppingId)
    {
        var pizzaToUpdate = _db.Pizzas.Find(pizzaId);
        var toppingToAdd = _db.Toppings.Find(toppingId);

        if (pizzaToUpdate is null || toppingToAdd is null)
        {
            throw new InvalidOperationException("Pizza or topping does not exist");
        }

        if(pizzaToUpdate.Toppings is null)
        {
            pizzaToUpdate.Toppings = new List<Topping>();
        }

        pizzaToUpdate.Toppings.Add(toppingToAdd);

        _db.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var pizzaToDelete = _db.Pizzas.Find(id);
        if (pizzaToDelete is not null)
        {
            _db.Pizzas.Remove(pizzaToDelete);
            _db.SaveChanges();
        }        
    }

}