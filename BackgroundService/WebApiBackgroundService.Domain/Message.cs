namespace WebApiBackgroundService.Domain
{
    public sealed class Message
    {
        public string Content { get; set; }
        public bool Continue { get; set; }
    }
}