using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Hello_world
{
    public class HumanFactory
    {
        private List<PeopleDescriptor> _listPeople = new List<PeopleDescriptor>();
        private ConsoleTextViewer.Button _buttonCreateHuman;
        private ConsoleTextViewer.Button _buttonShowList;
        private ConsoleTextViewer.Button _buttonMainMenu;
        private Action _menuStartAction;
        private Action<List<ConsoleTextViewer.Button>> _actionButtonMaping;
        private List<ConsoleTextViewer.Button> _listTextViewer = new List<ConsoleTextViewer.Button>();
        

        public HumanFactory(Action<List<ConsoleTextViewer.Button>> actionButtonMaping, Action menuStartAction)
        {
            _actionButtonMaping += actionButtonMaping;
            _menuStartAction += menuStartAction;
            _buttonCreateHuman = new ConsoleTextViewer.Button("CreateHuman", CreateHuman);
            _buttonShowList = new ConsoleTextViewer.Button("Show Human List", ListHuman);
            _buttonMainMenu = new ConsoleTextViewer.Button("Go to Main Menu", MainMenu);
            
            _listTextViewer.Add(_buttonCreateHuman);
            _listTextViewer.Add(_buttonShowList);
            _listTextViewer.Add(_buttonMainMenu);
        }

        public void Start()
        {   
            Console.WriteLine("Hello! You are on the human factory! Congratulations!");
            _actionButtonMaping.Invoke(_listTextViewer);        
        }
        private void ListHuman()
        {
            foreach (PeopleDescriptor item in _listPeople)
            {

                Console.WriteLine($"Name: {item.Name}, Age: {item.Age}, price(in euro): {item.Price}");
                
            }
            _actionButtonMaping.Invoke(_listTextViewer);
        }
        private void CreateHuman()
        {
            Console.WriteLine("\nPlease enter the  name of new human");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the  age of new human");
            byte age = byte.Parse(Console.ReadLine());
            Console.WriteLine("What will be the price of new human");
            int price = int.Parse(Console.ReadLine());
            CreateHuman(name, age, price);
            _actionButtonMaping.Invoke(_listTextViewer);
        }
        private void CreateHuman(string name, int age, int price)
        {
            PeopleDescriptor human = new PeopleDescriptor(name, age, price);
            _listPeople.Add(human);
        }
        private void MainMenu()
        {
            _menuStartAction.Invoke();
        }
    }
}
