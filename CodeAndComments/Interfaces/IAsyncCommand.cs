using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeAndComments.Interfaces
{
    interface IAsyncCommand : ICommand
    {
        public Task ExecuteAsync(object parameter);

    }
}
