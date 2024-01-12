using WebApiBackgroundService.Domain;

namespace WebApiBackgroundService.Repository
{
    public interface ICommandRepository
    {
        string GetMessage();
        void SetMessage(Message message);
    }
}
