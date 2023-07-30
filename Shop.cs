using System;
using System.Collections.Generic;

namespace Hello_world
{
    public class Shop
    {
        private List<PeopleDescriptor> _listPeople = new List<PeopleDescriptor>();
        private Action _comeBackAction;
        private Action<List<ConsoleTextViewer.Button>> _actionButtonMaping;
        private List<ConsoleTextViewer.Button> _listTextViewer = new List<ConsoleTextViewer.Button>();
        private ConsoleTextViewer.Button _buttonMainMenu;
        private ISellable _factoryBuyhuman;
        public Shop(ConsoleTextViewer textViewer, Action comeBackAction, ISellable factoryBuyHuman)
        {
            _factoryBuyhuman = factoryBuyHuman;
            _actionButtonMaping += textViewer.ButtonMapingCallBack;
            _comeBackAction += comeBackAction;
            _buttonMainMenu = new ConsoleTextViewer.Button("Go to Main Menu", MainMenu);
            _listTextViewer.Add(_buttonMainMenu);
            
        }
        public void Start()
        {
            Console.WriteLine("Hello! You are in the human shop! What would you like to buy?");
            _factoryBuyhuman.SellRequest();
            _comeBackAction.Invoke();
        }

        
        
        private void Buy()
        {

        }

        private void MainMenu()
        {
            _comeBackAction.Invoke();
        }
    }
}