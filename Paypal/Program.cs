using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Paypal
{
    class Program
    {
        public static string PasswordGenerate(int length)
        {
            Random _random = new Random(Environment.TickCount);

            string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
                builder.Append(chars[_random.Next(chars.Length)]);

            return builder.ToString();
        }

        public static void SummerizeAllCurrencies(double usersAmountOfMoney) //Передается колчисетво денег на счету пользователя; Словарь проходит от начала до конца и подсчитывает тем самым сумму для каждого курса, умножая количество денег пользователя на курс 
        {
            WriteLine(usersAmountOfMoney + " Тенге");
            WriteLine(usersAmountOfMoney * 5 + " Рубля");
            WriteLine(usersAmountOfMoney * 372 + " Доллара");
            WriteLine(usersAmountOfMoney * 400 + " Евро");
        }

        static void Main(string[] args)
        {

            MessageSender messageSender = new MessageSender();

            string passCode = PasswordGenerate(4);

            string key = "kz7d1d0bd1eb01d7c15a163be8b8c8151bbb1247259011124a340378dd7dea216aa078";

            int triesLeftFirst = 3;

            WriteLine("Создайте свой аккаунт");
            WriteLine();

            WriteLine("Введите номер телефона");
            string num = ReadLine();
            Clear();

            string message = "Сіздің аккаунттың коды " + passCode;

            string url = $"https://api.mobizon.kz/service/message/sendsmsmessage?recipient={num}&text={message}%21&apiKey={key}";

            WriteLine("Введите пароль");
            string password = ReadLine();
            Clear();

            while (triesLeftFirst > 0)
            {
                WriteLine("Введите код подтверждения");
                messageSender.GetRequest(url);
                string code = ReadLine();

                if (code == passCode)
                {
                    WriteLine("Аккаунт успешно подтвержден!");
                    break;
                }
                else
                {
                    triesLeftFirst--;
                    WriteLine("Осталось попыток - " + triesLeftFirst);
                }
            }

            if (triesLeftFirst < 0)
            {
                WriteLine("Нет попыток");
                WriteLine("Повторите позже");
                ReadLine();
                return;
            }

            Account account = new Account(num, password);
            account.Messenger = messageSender;

            int menuChoice = 0;
            while (true)
            {
                WriteLine("1.Добавить деньги на счет");
                WriteLine("2.Вывести деньги с счета");
                WriteLine("3.Перевести деньги на другой кошелек");
                WriteLine("4.Профиль");
                WriteLine("5.Выход");

                string str = ReadLine();

                bool isParsed = int.TryParse(str, out menuChoice);

                if (isParsed)
                    menuChoice = int.Parse(str);
                else
                {
                    Clear();
                    continue;
                }
                Clear();
                if (menuChoice <= 5)
                {
                    switch (menuChoice)
                    {
                        case 1:
                            {
                                int currencyChoice;
                                while(true)
                                {
                                WriteLine("Введте валюту для количества денег:");
                                WriteLine("1.Тенге");
                                WriteLine("2.Евро");
                                WriteLine("3.Рубль");
                                WriteLine("4.Доллар");

                                    str = ReadLine();

                                    isParsed = int.TryParse(str, out currencyChoice);

                                    if (isParsed)
                                        currencyChoice = int.Parse(str);

                                    if (currencyChoice < 5)
                                        break;
                                    Clear();
                                }
                                
                                WriteLine("Введте колчиество денег, которые хотите добавить:");

                                double sum;

                                str = ReadLine();

                                isParsed = double.TryParse(str, out sum);

                                if (isParsed)
                                    sum = double.Parse(str);

                                switch(currencyChoice)
                                {
                                    case 1: account.Add(sum, Currency.KZT); break;
                                    case 2: account.Add(sum, Currency.EUR); break;
                                    case 3: account.Add(sum, Currency.RUB); break;
                                    case 4: account.Add(sum, Currency.USD); break;
                                }

                                ReadLine();
                                Clear();
                            }
                            break;
                        case 2:
                            {
                                int currencyChoice;
                                while (true)
                                {
                                    WriteLine("Введте валюту для количества денег:");
                                    WriteLine("1.Тенге");
                                    WriteLine("2.Евро");
                                    WriteLine("3.Рубль");
                                    WriteLine("4.Доллар");

                                    str = ReadLine();

                                    isParsed = int.TryParse(str, out currencyChoice);

                                    if (isParsed)
                                        currencyChoice = int.Parse(str);

                                    if (currencyChoice < 5)
                                        break;
                                    Clear();
                                }

                                WriteLine("Введте колчиество денег, которые хотите добавить:");

                                double sum;

                                str = ReadLine();

                                isParsed = double.TryParse(str, out sum);

                                if (isParsed)
                                    sum = double.Parse(str);

                                switch (currencyChoice)
                                {
                                    case 1: account.Withdraw(sum, Currency.KZT); break;
                                    case 2: account.Withdraw(sum, Currency.EUR); break;
                                    case 3: account.Withdraw(sum, Currency.RUB); break;
                                    case 4: account.Withdraw(sum, Currency.USD); break;
                                }

                                ReadLine();
                                Clear();
                            }
                            break;
                        case 3:
                            {
                                int currencyChoice;
                                while (true)
                                {
                                    WriteLine("Введте валюту для количества денег:");
                                    WriteLine("1.Тенге");
                                    WriteLine("2.Евро");
                                    WriteLine("3.Рубль");
                                    WriteLine("4.Доллар");

                                    str = ReadLine();

                                    isParsed = int.TryParse(str, out currencyChoice);

                                    if (isParsed)
                                        currencyChoice = int.Parse(str);

                                    if (currencyChoice < 5)
                                        break;
                                    Clear();
                                }

                                WriteLine("Введте колчиество денег, которые хотите добавить:");

                                double sum;

                                str = ReadLine();

                                isParsed = double.TryParse(str, out sum);

                                if (isParsed)
                                    sum = double.Parse(str);

                                WriteLine("Введите номер телефона кошелька на который хотите отправить деньги");

                                string phoneNumber;

                                phoneNumber = ReadLine();

                                switch (currencyChoice)
                                {
                                    case 1: account.TransferToAnotherWallet(sum, Currency.KZT,phoneNumber); break;
                                    case 2: account.TransferToAnotherWallet(sum, Currency.EUR,phoneNumber); break;
                                    case 3: account.TransferToAnotherWallet(sum, Currency.RUB,phoneNumber); break;
                                    case 5: account.TransferToAnotherWallet(sum, Currency.USD,phoneNumber); break;
                                }

                                ReadLine();
                                Clear();
                            }
                            break;
                        case 4:
                            {
                                WriteLine("Ваш номер телефона:" + account.GetPhoneNumber());

                                WriteLine("Счет:");

                                SummerizeAllCurrencies(account.GetSum());

                                ReadLine();
                                Clear();
                            }
                            break;
                        case 5:
                            {
                            }
                            break;
                    }

                }
                else
                {
                    Clear();
                    continue;
                }

            }
            
        }
    }
}

