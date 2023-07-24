namespace Hello_world
{
    public class PeopleDescriptor
    {

        
        public int Age
        {
            get;
            private set;
        }
        public string Name
        {
            get;
            private set;
        }
        public int Price {
            get; 
            private set;
        }

        public PeopleDescriptor(string name, int age, int price)
        {
            Name = name;
            Age = age;
            Price = price;
        }
    }
}
