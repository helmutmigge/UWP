using Prism.Events;
using PrismCRUD.Events;
using PrismCRUD.Models;
using PrismCRUD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrismCRUD.Services
{
    public class AutoCreatePersonServiceImpl : IAutoCreatePersonService
    {
        private IPersonRepository personRepository;
        private CancellationTokenSource source;
        private IEventAggregator eventAggregator;        
        private bool started;

        public AutoCreatePersonServiceImpl(IPersonRepository personRepository, IEventAggregator eventAggregator) {
            this.personRepository = personRepository;
            this.source = new CancellationTokenSource();
            this.eventAggregator = eventAggregator;
            this.started = false;

        }

        public Task cancelAsync()
        {
           return  Task.Run(() =>
            {                          
                 this.source.Cancel();                 
            });
            
        }

        public bool IsStarted()
        {
            return started;
        }

        public Task startAsync()
        {
            if (!this.started)
            {
                return Task.Run(async () =>
                {
                    this.started = true;
                    while (!source.IsCancellationRequested)
                    {
                        int Count = (await personRepository.GetPersonAsync()).Count + 1;

                        Person person = new Person($"Default name {Count}", Count);
                        await this.personRepository.SavePersonAsync(person);
                        this.eventAggregator.GetEvent<AddPersonEvent>().Publish(person);
                        await Task.Delay(500);
                    }
                    this.started = false;
                }, source.Token);
            }
            else {
                return Task.FromException(new ArgumentException());
            }
            
        }
    }
}
