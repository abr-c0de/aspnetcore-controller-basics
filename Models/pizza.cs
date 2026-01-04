namespace PappaPizza.Models
{

    //Models are classes that defines our entities
    public class Pizza
    {
        //id is a primarykey column which uniquely identify each row of the table
        public int Id { get; set; }

        //Define the attributes of pizza entity

        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
