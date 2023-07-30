namespace Hello_world
{
    public enum SkinColor 
    {
        White, Black
    }
    public enum AgeGroup
    {
        baby, child, teenager, growth, middleage, pensioneer
    }

    public class PeopleDescriptor
    {

        public SkinColor SkinColor { get; private set; }
        public AgeGroup AgeGroup
        {
            get
            {
                if (Age < 6)
                    return AgeGroup.baby;
                else if (Age >= 6 && Age < 12)
                    return AgeGroup.child;
                else if (Age >= 12 && Age < 18)
                    return AgeGroup.teenager;
                else if (Age >= 18 && Age < 65)
                    return AgeGroup.growth;
                else 
                    return AgeGroup.pensioneer;
            }
        }


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

        public PeopleDescriptor(string name, int age, int price, SkinColor skinColor)
        {
            Name = name;
            Age = age;
            Price = price;
            SkinColor = skinColor;  
        }
    }
}
