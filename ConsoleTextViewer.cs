using System;
using System.Collections.Generic;

namespace Hello_world
{
    public class ConsoleTextViewer
    {
        public class Button
        {
            public string Text { get; private set; }
            public Action Action;
            public Button(string text, Action action)
            {
                Text = text;
                Action += action;
            }

        }
        public void ButtonMapingCallBack(List<Button> buttons)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                int index = i;
                index++;
                Console.WriteLine($"{index}. {buttons[i].Text}");
            }
            int userOutput = int.Parse(Console.ReadLine());
            userOutput--;
            buttons[userOutput].Action.Invoke();
                       
        }
        
    }
}
