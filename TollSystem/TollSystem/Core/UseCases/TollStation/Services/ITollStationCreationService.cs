using System.Collections.Generic;

namespace TollSystem.Commands.TollStationCreation
{
    public interface ITollStationCreationService
    {
        public bool CreateStation(string name, int numberOfBooths, Dictionary<int, List<double>> sections);
    }
}