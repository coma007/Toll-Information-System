using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;

namespace TollSystem.Commands
{
    class DeleteTollStationCommand : BaseCommand
    {

        private TollStationEntity _selectedStation;

        public DeleteTollStationCommand()
        {
        }

        public override void Execute(object parameter)
        {
        }
    }
}
