using System;
using System.Collections.Generic;

namespace Hello_world
{
    class Shop
    {
        private Action _comeBackAction;
        private Action<List<ConsoleTextViewer.Button>> _actionButtonMaping;
        private List<PeopleDescriptor> _listPeople = new List<PeopleDescriptor>();
        private List<ConsoleTextViewer.Button> _listTextViewer = new List<ConsoleTextViewer.Button>();
        private ConsoleTextViewer.Button _buttonShowGoodsList;
        private ConsoleTextViewer.Button _buttonShowCart;
        private ConsoleTextViewer.Button _buttonAddToCart;
        private ConsoleTextViewer.Button _buttonMainMenu;
        public Shop(Action<List<ConsoleTextViewer.Button>> actionButtonMaping, Action comeBackAction)
        {
            _actionButtonMaping += actionButtonMaping;
            _comeBackAction += comeBackAction;
            _buttonShowGoodsList = new ConsoleTextViewer.Button("Show goods list", ShowGoodsList);
            _buttonShowCart = new ConsoleTextViewer.Button("Show Cart", ShowCart);
            _buttonAddToCart = new ConsoleTextViewer.Button("Add to Cart", AddToCart);
            _buttonMainMenu = new ConsoleTextViewer.Button("Go to Main Menu", MainMenu);

            _listTextViewer.Add(_buttonShowGoodsList);
            _listTextViewer.Add(_buttonShowCart);
            _listTextViewer.Add(_buttonAddToCart);
            _listTextViewer.Add(_buttonMainMenu);
        }
        public void Start()
        {
            Console.WriteLine("Hello! You are in the human shop! What would you like to buy?");
            _actionButtonMaping.Invoke(_listTextViewer);
        }

        private void ShowGoodsList()
        {
            
        }
        
        private void ShowCart()
        {

            Console.WriteLine("Stash");

            Console.WriteLine("nsofvudgsnbiungf");

        }

        private void AddToCart()
        {

        }

        private void MainMenu()
        {
            _comeBackAction.Invoke();
        }
    }
}