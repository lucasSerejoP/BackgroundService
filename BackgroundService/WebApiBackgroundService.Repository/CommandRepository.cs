using WebApiBackgroundService.Domain;

namespace WebApiBackgroundService.Repository
{
    public class CommandRepository : ICommandRepository
    {
        private Message _message;
        public CommandRepository()
        {
            _message = new Message
            {
                Content = "Teste inicial"
            };
        }
        public string GetMessage()
        {
            return _message.Content;
        }

        public void SetMessage(Message message)
        {
            _message = message;
        }
    }
}