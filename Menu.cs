using System;
using System.Collections.Generic;

namespace Hello_world
{
    public class Menu
    {
        private ConsoleTextViewer.Button _factoryEnter;
        private ConsoleTextViewer.Button _shopEnter;
        private ConsoleTextViewer.Button _programClose;
        private HumanFactory _human;
        private ShopHumans _shopHumans;
        private ConsoleTextViewer _textViewer = new ConsoleTextViewer();
        private List<ConsoleTextViewer.Button> _listMenu;
        
        private Action _menuStartAction;
        public Menu()
        {
            _menuStartAction += Start;
            _human = new HumanFactory(_textViewer, _menuStartAction);
            _shopHumans = new ShopHumans(_textViewer, _menuStartAction, _human);
            _factoryEnter = new ConsoleTextViewer.Button("Go to Factory", _human.Start);
            _shopEnter = new ConsoleTextViewer.Button("Go to ShopHumans", _shopHumans.Start);
            _programClose = new ConsoleTextViewer.Button("Close the program", ()=> { });
            _listMenu = new List<ConsoleTextViewer.Button>() { _factoryEnter, _shopEnter, _programClose};
        }

        public void Start()
        {
            Console.Clear();
            _textViewer.ButtonMapingCallBack(_listMenu);
        }
    
    }
}
