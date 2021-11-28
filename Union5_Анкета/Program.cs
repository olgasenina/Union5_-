using System;

namespace Union5_Анкета
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                Необходимо написать программу в классе Program со следующим функционалом:

                Необходимо создать метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж):
                Имя;
                Фамилия;
                Возраст;
                Наличие питомца;
                Если питомец есть, то запросить количество питомцев;
                Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек (заполнение с клавиатуры);
                Запросить количество любимых цветов;
                Вызвать метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры);
                Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе;
                Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен;
                Корректный ввод: ввод числа типа int больше 0.
                Метод, который принимает кортеж из предыдущего шага и показывает на экран данные.
                Вызов методов из метода Main.
            */

            // Кортеж с данными пользователя
            (string FirstName, string LastName, int Age, bool HasPet, int QntPet, string[] PetNames, int QntColor, string[] ColorNames) User;

            // Метод для заполнения данных пользователя
            GetUserData(out User);

            // Метод, который показывает на экран данные
            ShowUserData(User);


            Console.WriteLine("\n\nДля выхода из приложения нажмите любую клавишу");
            Console.ReadKey();
        }

        // Метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж): Имя, Фамилия, Возраст, Наличие питомца.
        // Если питомец есть, то запросить количество питомцев - вызвать метод для заполнения списка питомцев
        // Запросить количество любимых цветов - вызвать метод для заполнения списка цветов
        static void GetUserData(out (string FirstName, string LastName, int Age, bool HasPet, int QntPet, string[] PetNames, int QntColor, string[] ColorNames) User) 
        {
            string strNumber = "";
            bool CheckNumberResult = false;

            Console.WriteLine("");
            Console.Write("Введите Ваши данные.\nИмя: ");
            User.FirstName = Console.ReadLine();
            Console.Write("Фамилия: ");
            User.LastName = Console.ReadLine();

            // Возраст 

            do
            {
                Console.Write("Сколько Вам лет? ");
                strNumber = Console.ReadLine();

                CheckNumberResult = CheckNumber(strNumber, out User.Age);
            }
            while (!CheckNumberResult);

            // Домашние животные

            Console.Write("Есть ли у Вас домашнее животное? (да/нет): ");
            if (Console.ReadLine() == "да")
            {
                User.HasPet = true;
            }
            else
            {
                User.HasPet = false;
            }

            // Вопросы о домашних животных

            strNumber = "";
            CheckNumberResult = false;

            if (User.HasPet == true)
            {
                // Спросим количество животных
                do
                {
                    Console.Write("Сколько у Вас домашних животных? ");
                    strNumber = Console.ReadLine();

                    // Проверка значения
                    CheckNumberResult = CheckNumber(strNumber, out User.QntPet);
                }
                while (!CheckNumberResult);


                // Спросим их имена

                Console.WriteLine("Введите их имена: ");

                User.PetNames = new string[User.QntPet];

                for (int i = 0; i < User.QntPet; i++)
                {
                    Console.Write("{0}. ", i+1);
                    User.PetNames[i] = Console.ReadLine();
                }
            }
            else
            {
                User.QntPet = 0;
                User.PetNames = new string[1] { "" };
            }

            // Список любимых цветов

            strNumber = "";
            CheckNumberResult = false;

            do
            {
                Console.Write("Сколько у Вас любимых цветов? ");
                strNumber = Console.ReadLine();

                // Проверка значения
                CheckNumberResult = CheckNumber(strNumber, out User.QntColor);
            }
            while (!CheckNumberResult);

            // Спросим их названия

            User.ColorNames = new string[User.QntColor];

            Console.WriteLine("Введите их наименования: ");

            for (int i = 0; i < User.QntColor; i++)
            {
                Console.Write("{0}. ", i + 1);
                User.ColorNames[i] = Console.ReadLine();
            }
        }

        // Вывести на экран данные анкеты
        static void ShowUserData((string FirstName, string LastName, int Age, bool HasPet, int QntPet, string[] PetNames, int QntColor, string[] ColorNames) User)
        {
            string strName = "";

            Console.WriteLine("\n\n\nИтак, что удалось узнать:\nВаше имя " + User.LastName + " " + User.FirstName + ", Вам " + User.Age + " лет.");

            // Домашние животные

            if(User.HasPet)
            {
                foreach(var name in User.PetNames)
                {
                    strName = strName + ", " + name;
                }

                strName = strName.Remove(0, 2);

                Console.WriteLine("Ваши домашние животные: " + strName + ".");
            }
            else
            {
                Console.WriteLine("У Вас нет домашних животных.");
            }

            // Цвета

            strName = "";
            
            foreach (var name in User.ColorNames)
            {
                strName = strName + ", " + name;
            }

            strName = strName.Remove(0, 2);

            Console.WriteLine("Ваши любимые цвета: " + strName + ".");
        }

        // Проверить корректность ввода числа
        static bool CheckNumber(string StrNumber, out int IntNumber)
        {
            bool IsCorrect = int.TryParse(StrNumber, out IntNumber);

            if(IsCorrect == false)
            {
                Console.WriteLine("Ошибка! Введите число.");
            }
            else if(IntNumber <= 0)
            {
                Console.WriteLine("Ошибка! Число должно быть больше 0.");
                IsCorrect = false;
            }

            return IsCorrect;
        }
    }
}
