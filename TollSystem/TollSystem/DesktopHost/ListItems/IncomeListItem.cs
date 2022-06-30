using System.Collections.Generic;
using System.Windows.Documents;

namespace TollSystem.DesktopHost.ListItems
{
    public class IncomeListItem
    {
        public string TollStationName { get; set; }
        public double RSDIncome { get; set; }
        public double EURIncome { get; set; }

        public IncomeListItem(string name, List<double> income)
        {
            TollStationName = name;
            RSDIncome = income[0];
            EURIncome = income[1];
        }
    }
}