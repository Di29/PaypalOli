using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paypal
{
    public class Account
    {
        private double Sum { get; set; }

        private string PhoneNumber { get; set; }

        private string Password { get; set; }

        public IMessenger Messenger { get; set; }

        public Account()
        {

        }

        public Account(string phoneNumber,string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public void Add(double sum,Currency currency)
        {
            string message = "";
            if (sum > 0)
            {
                if (currency == Currency.KZT && Messenger != null)
                {
                    Sum += sum;
                    Messenger.SendMessage("Вы добавили на свой счет " + sum + " ТГ");
                    message = "Есептік жазбаңызға " + sum + " тг сома қосылды";
                }
                if (currency == Currency.EUR && Messenger != null)
                {
                    Sum += sum*400;
                    Messenger.SendMessage("Вы добавили на свой счет " + sum + " евро");
                    message = "Есептік жазбаңызға " + sum + " евро сома қосылды";
                }
                if (currency == Currency.RUB && Messenger != null)
                {
                    Sum += sum*5; 
                    Messenger.SendMessage("Вы добавили на свой счет " + sum + " руб");
                    message = "Есептік жазбаңызға " + sum + " рубль сома қосылды";
                }
                if (currency == Currency.USD && Messenger != null)
                {
                    Sum += sum*372;
                    Messenger.SendMessage("Вы добавили на свой счет " + sum + " долларов");
                    message = "Есептік жазбаңызға " + sum + " доллар сома қосылды";
                }
            }
            else
                Messenger.SendMessage("Неправильно введена сумма");

            string key = "kz7d1d0bd1eb01d7c15a163be8b8c8151bbb1247259011124a340378dd7dea216aa078";

            string url = $"https://api.mobizon.kz/service/message/sendsmsmessage?recipient={PhoneNumber}&text={message}%21&apiKey={key}";

            Messenger.GetRequest(url);
        }

        public void Withdraw(double sum, Currency currency)
        {
            string message = "";

            if (Sum >= sum && sum > 0)
            {
                if (currency == Currency.KZT && Messenger != null)
                {
                    Sum -= sum;
                    Messenger.SendMessage("Вы сняли со своего счета " + sum + " тг");
                    message = "Cіз өзіңіздің есептік жазбаңыздан " + sum + " тг бөлдініз";
                    Messenger.SendMessage("Остаток " + Sum);
                }
                if (currency == Currency.EUR && Sum >= sum*400 && Messenger != null)
                {
                    Sum -= sum*400;
                    Messenger.SendMessage("Вы сняли со своего счета " + sum + " евро");
                    message = "Cіз өзіңіздің есептік жазбаңыздан " + sum + " евро бөлдініз";
                    Messenger.SendMessage("Остаток " + Sum + "тг");
                }
                if (currency == Currency.RUB && Sum >= sum*5 && Messenger != null)
                {
                    Sum -= sum*5;
                    Messenger.SendMessage("Вы сняли со своего счета " + sum + " руб");
                    message = "Cіз өзіңіздің есептік жазбаңыздан " + sum + " руб бөлдініз";
                    Messenger.SendMessage("Остаток " + Sum + "тг");
                }
                if (currency == Currency.USD && Sum >= sum*372 && Messenger != null)
                {
                    Sum -= sum*372;
                    Messenger.SendMessage("Вы сняли со своего счета " + sum + " долларов");
                    message = "Cіз өзіңіздің есептік жазбаңыздан " + sum + " доллар бөлдініз";
                    Messenger.SendMessage("Остаток " + Sum + "тг");
                }
            }
            else
                Messenger.SendMessage("Недостаточно средства");

            string key = "kz7d1d0bd1eb01d7c15a163be8b8c8151bbb1247259011124a340378dd7dea216aa078";

            string url = $"https://api.mobizon.kz/service/message/sendsmsmessage?recipient={PhoneNumber}&text={message}%21&apiKey={key}";

            Messenger.GetRequest(url);
        }

        public void TransferToAnotherWallet(double sum, Currency currency, string num)
        {
            string message = "";
            if (Sum >= sum && sum > 0)
            {
                if (currency == Currency.KZT && Messenger != null)
                {
                    Sum -= sum;
                    Messenger.SendMessage("Вы сняли со своего счета " + sum + " тг");
                    message = "Есептік жазбаңызға " + sum + " тг сома қосылды";
                    Messenger.SendMessage("Остаток " + Sum);
                }
                if (currency == Currency.EUR && Sum >= sum * 400 && Messenger != null)
                { 
                    Sum -= sum * 400;
                    Messenger.SendMessage("Вы сняли со своего счета " + sum + " евро");
                    message = "Есептік жазбаңызға " + sum + " евро сома қосылды";
                    Messenger.SendMessage("Остаток " + Sum + "тг");
                }
                if (currency == Currency.RUB && Sum >= sum * 5 && Messenger != null)
                {
                    Sum -= sum * 5;
                    Messenger.SendMessage("Вы сняли со своего счета " + sum + " руб");
                    message = "Есептік жазбаңызға " + sum + " рубль сома қосылды";
                    Messenger.SendMessage("Остаток " + Sum + "тг");
                }
                if (currency == Currency.USD && Sum >= sum * 372 && Messenger != null)
                {
                    Sum -= sum * 372;
                    Messenger.SendMessage("Вы сняли со своего счета " + sum + " долларов");
                    message = "Есептік жазбаңызға " + sum + " доллар сома қосылды";
                    Messenger.SendMessage("Остаток " + Sum + "тг");
                }
            }
            else
                Messenger.SendMessage("Недостаточно средства");

            string key = "kz7d1d0bd1eb01d7c15a163be8b8c8151bbb1247259011124a340378dd7dea216aa078";

            string url = $"https://api.mobizon.kz/service/message/sendsmsmessage?recipient={num}&text={message}%21&apiKey={key}";

            Messenger.GetRequest(url);
        }

        public void SetPassword(string password) //добавил только изменение пароля потому что в здоровых системах пароль не показывется 
        {
            //добавляет подтвреждение кодом Диас 
            Password = password;
            Messenger.SendMessage("Пароль изменен");
        }

        public double GetSum() //добавил геттер для суммы денег потому что будет востребована в системе
        {
            return Sum;
        }

        public string GetPhoneNumber()
        {
            return PhoneNumber;
        }
    }
}
