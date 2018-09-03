using Prism.Events;
using PrismCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCRUD.Events
{
    public class AddPersonEvent: PubSubEvent<Person>
    {
    }
}
