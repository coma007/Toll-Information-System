using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class TollBooth
    {
        public int OrdinalNumber { get; set; }
        public TollStation TollStation { get; set; }
        public TicketReader TickerReader { get; set; }
        public Printer RecieptPrinter { get; set; }
        public Printer TicketPrinter { get; set; }
        public Semaphore Semahore { get; set; }
        public Ramp Ramp { get; set;}
        public Scanner TagScanner { get; set;} 
        public Scanner LicensePlateScanner { get; set; }

        public TollBooth()
        {

        }

        public TollBooth(int ordinalNumber, TollStation tollStation, TicketReader ticketReader,
                         Printer recieptPrinter, Semaphore semaphore, Ramp ramp,
                         Scanner tagScanner, Scanner licensePlateScanner)
        {
            OrdinalNumber = ordinalNumber;
            TollStation = tollStation;
            TickerReader = ticketReader;
            RecieptPrinter = recieptPrinter;
            Semahore = semaphore;
            Ramp = ramp;
            TagScanner = tagScanner;
            LicensePlateScanner = licensePlateScanner;
        }


    }
}
