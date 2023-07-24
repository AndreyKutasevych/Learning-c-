using System;
using System.Collections.Generic;

namespace Hello_world
{
    public class Menu
    {
        private ConsoleTextViewer.Button _factoryEnter;
        private ConsoleTextViewer.Button _shopEnter;
        private ConsoleTextViewer.Button _programClose;
        private HumanFactory _humanMenu;
        private Shop _shopMenu;
        private ConsoleTextViewer _textViewer = new ConsoleTextViewer();
        private List<ConsoleTextViewer.Button> _listMenu;
        private Action<List<ConsoleTextViewer.Button>> _buttonMaping;
        private Action _menuStartAction;
        public Menu()
        {
            _buttonMaping += _textViewer.ButtonMapingCallBack;
            _menuStartAction += Start;
            _humanMenu = new HumanFactory(_buttonMaping, _menuStartAction);
            _shopMenu = new Shop(_buttonMaping, _menuStartAction);
            _factoryEnter = new ConsoleTextViewer.Button("Go to Factory", _humanMenu.Start);
            _shopEnter = new ConsoleTextViewer.Button("Go to Shop", _shopMenu.Start);
            _programClose = new ConsoleTextViewer.Button("Close the program", ()=> { });
            _listMenu = new List<ConsoleTextViewer.Button>() { _factoryEnter, _shopEnter, _programClose};
        }

        public void Start()
        {
            _textViewer.ButtonMapingCallBack(_listMenu);
        }
    }
}
