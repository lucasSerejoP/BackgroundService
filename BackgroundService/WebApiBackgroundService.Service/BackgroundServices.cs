using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using WebApiBackgroundService.Domain;
using WebApiBackgroundService.Repository;

namespace WebApiBackgroundService.Service
{
    public class BackgroundServices : IHostedService
    {
        private Timer _timer;
        private ICommandRepository _commandRepository;
        private readonly IConfiguration _configuration;

        public BackgroundServices(ICommandRepository commandRepository, IConfiguration configuration)
        {
            _commandRepository = commandRepository;
            _configuration = configuration;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Process started{nameof(BackgroundServices)}");
            _timer = new Timer(
                DoWork,
                null,
                TimeSpan.FromSeconds(Convert.ToInt32(_configuration["TempoIniciar"])),
                TimeSpan.FromSeconds(Convert.ToInt32(_configuration["TempoProcessamento"])));
            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            bool continua =  Convert.ToBoolean(_configuration["BackgroundService"]);
            if (continua == true)
                Console.WriteLine($"{DateTime.Now:o} => {_commandRepository.GetMessage()}");
            // Alterar intervalo de execu~c"ao caso a ultima execucao retorne a quantidade de itens processados 0
            //
            _timer.Change(0, (5 * 60000));
            // else - Voltar o intervalo para o normal caso a ultima execucao retorne que processou algum item
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {

            Console.WriteLine($"Process interrupted{nameof(BackgroundServices)}");
            return Task.CompletedTask;
        }
    }
}