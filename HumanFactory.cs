using System;
using System.Collections.Generic;

namespace Hello_world
{
    public class HumanFactory : BaseShop<PeopleDescriptor>
    {
        private Action<List<ConsoleTextViewer.Button>> _actionButtonMaping;
        private Func<List<ConsoleTextViewer.ButtonReturning<SkinColor>>, SkinColor> _skinColorChoose;
        private Func<List<ConsoleTextViewer.ButtonReturning<AgeGroup>>, AgeGroup> _ageGroupChoose;


        private ConsoleTextViewer.Button _buttonFullList;
        private ConsoleTextViewer.Button _buttonSkinColorSort;
        private ConsoleTextViewer.Button _buttonAgeSort;
        private ConsoleTextViewer.Button _buttonCreateHuman;
        private ConsoleTextViewer.Button _buttonShowList;
        private ConsoleTextViewer.Button _buttonMainMenu;


        private List<ConsoleTextViewer.ButtonReturning<SkinColor>> _listSkinColorReturn =
            new List<ConsoleTextViewer.ButtonReturning<SkinColor>>();

        private List<ConsoleTextViewer.ButtonReturning<AgeGroup>> _listAgeGroupReturn =
            new List<ConsoleTextViewer.ButtonReturning<AgeGroup>>();

        private List<ConsoleTextViewer.Button> _listTextViewerMainButtons = new List<ConsoleTextViewer.Button>();
        private List<ConsoleTextViewer.Button> _listHumanMainSortButtons = new List<ConsoleTextViewer.Button>();
        private List<ConsoleTextViewer.Button> _listColorChoose = new List<ConsoleTextViewer.Button>();
        private List<PeopleDescriptor> _listPeopleNotActual = new List<PeopleDescriptor>();
        private List<SkinColor> _listSkinColor = new List<SkinColor>();
        private List<AgeGroup> _listAgeGroup = new List<AgeGroup>();

        public HumanFactory(ConsoleTextViewer textViewer, Action menuStartAction) : base(menuStartAction)
        {
            _skinColorChoose += textViewer.ChooseButtonType;
            _ageGroupChoose += textViewer.ChooseButtonType;
            _actionButtonMaping += textViewer.ButtonMapingCallBack;
            _buttonCreateHuman = new ConsoleTextViewer.Button("CreateHuman", CreateHuman);
            _buttonShowList = new ConsoleTextViewer.Button("Show Human List", ListHuman);
            _buttonMainMenu = new ConsoleTextViewer.Button("Go to Main Menu", ComeBackMenu);
            
            _buttonFullList = new ConsoleTextViewer.Button("Show full list of humans", Sort);
            _buttonSkinColorSort = new ConsoleTextViewer.Button("Sort by skin color", () => Sort(SkinColorChoose()));
            _buttonAgeSort = new ConsoleTextViewer.Button("Sort by age", () => Sort(AgeGroupChoose()));

            _listHumanMainSortButtons.Add(_buttonFullList);
            _listHumanMainSortButtons.Add(_buttonSkinColorSort);
            _listHumanMainSortButtons.Add(_buttonAgeSort);

            _listTextViewerMainButtons.Add(_buttonCreateHuman);
            _listTextViewerMainButtons.Add(_buttonShowList);
            _listTextViewerMainButtons.Add(_buttonMainMenu);

            _listSkinColor.Add(SkinColor.White);
            _listSkinColor.Add(SkinColor.Black);

            _listAgeGroup.Add(AgeGroup.baby);
            _listAgeGroup.Add(AgeGroup.child);
            _listAgeGroup.Add(AgeGroup.teenager);
            _listAgeGroup.Add(AgeGroup.growth);
            _listAgeGroup.Add(AgeGroup.middleage);
            _listAgeGroup.Add(AgeGroup.pensioneer);

            foreach (var color in _listSkinColor)
            {
                _listSkinColorReturn.Add(
                    new ConsoleTextViewer.ButtonReturning<SkinColor>(color.ToString(), () => color));
            }

            foreach (var ageGroup in _listAgeGroup)
            {
                _listAgeGroupReturn.Add(
                    new ConsoleTextViewer.ButtonReturning<AgeGroup>(ageGroup.ToString(), () => ageGroup));
            }
        }

        public override void Start()
        {
            Console.WriteLine("Hello! You are on the human factory! Congratulations!");
            _actionButtonMaping.Invoke(_listTextViewerMainButtons);
        }

        private SkinColor SkinColorChoose()
        {
            return _skinColorChoose.Invoke(_listSkinColorReturn);
        }

        private AgeGroup AgeGroupChoose()
        {
            return _ageGroupChoose.Invoke(_listAgeGroupReturn);
        }

        private void ListHuman()
        {
            _actionButtonMaping.Invoke(_listHumanMainSortButtons);
        }

        private void Sort()
        {
            foreach (PeopleDescriptor human in _products)
            {
                Console.WriteLine("Here is the full list of humans:");
                Console.WriteLine(
                    $"Name: {human.Name}, age: {human.Age}, price: {human.Price}, he is {human.AgeGroup}");
            }
        }

        private void Sort(SkinColor color)
        {
            List<PeopleDescriptor> _listPeopleMatch = new List<PeopleDescriptor>();
            foreach (var human in _products)
            {
                if (human.SkinColor == color)
                {
                    _listPeopleMatch.Add(human);
                }
            }

            Console.WriteLine($"I found {_listPeopleMatch.Count} {color} humans");
            foreach (PeopleDescriptor human in _listPeopleMatch)
            {
                Console.WriteLine(
                    $"Name: {human.Name}, age: {human.Age}, price: {human.Price}, he is {human.AgeGroup}");
            }
        }

        private void Sort(AgeGroup age)
        {
            List<PeopleDescriptor> _listPeopleMatch = new List<PeopleDescriptor>();
            foreach (var human in _products)
            {
                if (human.AgeGroup == age)
                {
                    _listPeopleMatch.Add(human);
                }
            }

            Console.WriteLine($"I found {_listPeopleMatch.Count} {age}s");
            foreach (PeopleDescriptor human in _listPeopleMatch)
            {
                Console.WriteLine(
                    $"Name: {human.Name}, age: {human.Age}, price: {human.Price}, he is {human.AgeGroup}");
            }
        }

        private void CreateHuman()
        {
            Console.WriteLine("\nPlease enter the  name of new human");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the  age of new human");
            byte age = byte.Parse(Console.ReadLine());
            Console.WriteLine("What will be the price of new human");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose the skin color below:");
            SkinColor skinColor = SkinColor.White;
            _listColorChoose.Clear();
            foreach (SkinColor color in _listSkinColor)
            {
                var _button = new ConsoleTextViewer.Button(color.ToString(), () => { skinColor = color; });
                _listColorChoose.Add(_button);
            }

            _actionButtonMaping.Invoke(_listColorChoose);
            CreateHuman(name, age, price, skinColor);
            Console.Clear();
            _actionButtonMaping.Invoke(_listTextViewerMainButtons);
        }

        private void CreateHuman(string name, int age, int price, SkinColor skinColor)
        {
            PeopleDescriptor human = new PeopleDescriptor(name, age, price, skinColor);
            _products.Add(human);
        }

        public override void SellRequest()
        {
            var human = _products[0];
            _listPeopleNotActual.Add(human);
            _products.Remove(human);
        }
    }
}