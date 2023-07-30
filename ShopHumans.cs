using System;
using System.Collections.Generic;

namespace Hello_world
{
    public class ShopHumans : BaseShop<PeopleDescriptor>
    {
        private Action<List<ConsoleTextViewer.Button>> _actionButtonMaping;
        private List<ConsoleTextViewer.Button> _listTextViewer = new List<ConsoleTextViewer.Button>();
        private ConsoleTextViewer.Button _buttonMainMenu;
        private ISellable _factoryBuyhuman;

        public ShopHumans(ConsoleTextViewer textViewer, Action comeBackAction, ISellable factoryBuyHuman) : base(
            comeBackAction)
        {
            _factoryBuyhuman = factoryBuyHuman;
            _actionButtonMaping += textViewer.ButtonMapingCallBack;
            _buttonMainMenu = new ConsoleTextViewer.Button("Go to Main Menu", ComeBackMenu);
            _listTextViewer.Add(_buttonMainMenu);
        }

        public override void SellRequest()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            Console.WriteLine("Hello! You are in the human shop! What would you like to buy?");
            _factoryBuyhuman.SellRequest();
        }
    }
}