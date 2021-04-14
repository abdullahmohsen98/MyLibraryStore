using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLibraryStore.Models;

namespace MyLibraryStore.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NewBookAlertConfig> _newBookAlertconfiguration;

        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> newBookAlertconfiguration)
        {
            _newBookAlertconfiguration = newBookAlertconfiguration;

        }
        public string GetName()
        {
            return _newBookAlertconfiguration.CurrentValue.BookName;
        }
    }
}
