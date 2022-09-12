using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandlers
{
    public class RabbitMqMessageHandler : IMessageHandler
    {
        // Класс - шаблон на случай установки реализации под RabbitMq
        public void SendMessage()
        {
            throw new NotImplementedException();
        }
    }
}
