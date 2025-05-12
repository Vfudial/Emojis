using Emojis;
using lab;

namespace Emojis
{
    public static class Inits
    {

        public static string StringInput(string type)
        {

            bool isChecked;
            string? input;
            do
            {

                Console.Write($"Введите {type}: ");
                input = Console.ReadLine();

                if (input == null)
                {
                    isChecked = false;
                    Outputs.BadMessage("Необходимо ввести данные!");
                }
                else
                    isChecked = true;
                
            } while (!isChecked);
            return input;
        }

        public static int IntInput(string type, int min, int max)
        {

            bool isChecked;
            int input;

            do
            {
                Console.Write($"Введите {type} (от {min} до {max}): ");
                isChecked = int.TryParse(Console.ReadLine(), out input);
                if (input < min || input > max)
                {
                    isChecked = false;
                    Console.WriteLine("Ошибка! Повторите попытку!");
                }
                else if (!isChecked)
                    Console.WriteLine("Ошибка! Повторите попытку!");

                else
                    isChecked = true;

            } while (!isChecked);

            return input;

        }

        public static int MenuChoice(string[] menu)
        {
            bool isValid;
            int menuChoice;
            do
            {
                foreach (string item in menu)
                {
                    Console.WriteLine(item);
                }
                Outputs.Message("Введите номер пункта:");
                isValid = int.TryParse(Console.ReadLine(), out menuChoice);
                if (!isValid || menuChoice > menu.Length)
                {
                    Outputs.BadMessage("Ошибка ввода!");
                    isValid = false;
                }
            } while (!isValid);
            return menuChoice; 
        }
    }
}