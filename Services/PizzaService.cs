using Microsoft.AspNetCore.Http.HttpResults;
using PappaPizza.Models;

//Services are classes that defines the business logic of models. 
//By organising these operations in the services classes,
//the code become modular and easier to maintain.
//The services can be used by other parts of the applications ,
//such as controllers, to perform these operations without duplicating code


namespace PappaPizza.Services
{
    public static class PizzaService
    {
        private static int nextId = 5;
        private static List<Pizza> Pizzas {  get; }

        static PizzaService()
        {
            Pizzas =
                [
                   new Pizza {Id = 1, Name = "Peperoni Pizza", IsGlutenFree = false},
                   new Pizza {Id = 2, Name = "Veggie Pizza", IsGlutenFree = true},
                   new Pizza {Id = 3, Name = "Maccaroni Pizza", IsGlutenFree = false},
                   new Pizza {Id = 4, Name = "Mushroom Pizza", IsGlutenFree = true},

                ];
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        //Create method to add a new Pizza object to the Listt
        public static void Add(Pizza pizza)
        {           

            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        //delete method to delete the pizza

        public static void Delete(Pizza pizza)
        {

            Pizzas.Remove(pizza);
        }

        //Update method for editing pizza details(object)
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p =>  p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }

    }
}
