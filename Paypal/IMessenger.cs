namespace Paypal
{
    public interface IMessenger
    {
        void SendMessage(string message);

        void GetRequest(string url);
    }
}