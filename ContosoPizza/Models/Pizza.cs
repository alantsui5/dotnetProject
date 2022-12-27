namespace ContosoPizza.Models;
using System.ComponentModel.DataAnnotations;

public class Pizza
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }


    public PizzaSize Size { get; set; }

    public bool IsGlutenFree { get; set; }

    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }

    public Sauce? Sauce { get; set; }

    public ICollection<Topping>? Toppings { get; set; }
}

public enum PizzaSize { Small, Medium, Large }