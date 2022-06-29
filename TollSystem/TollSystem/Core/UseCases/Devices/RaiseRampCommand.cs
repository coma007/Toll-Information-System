using System.Threading.Tasks;
using System.Windows.Input;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    public class RaiseRampCommand : BaseCommand
    {
        private ReferentViewModel _referentViewModel;

        public RaiseRampCommand(ReferentViewModel referentViewModel)
        {
            _referentViewModel = referentViewModel;
        }

        async public override void Execute(object parameter)
        { 
            int lastPosition = _referentViewModel.RampPosition;
            while (_referentViewModel.RampPosition != -50) {
                _referentViewModel.RampPosition -= 1;
                await Task.Delay(100);
            }
            _referentViewModel.SemaphoreState = "Green";
            await Task.Delay(3000);
            while (_referentViewModel.RampPosition != lastPosition)
            {
                _referentViewModel.RampPosition += 1;
                await Task.Delay(100);
            }
            _referentViewModel.SemaphoreState = "Red";
            _referentViewModel.ResetForm();
        }
    }
}