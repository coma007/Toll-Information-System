using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    public class TollBoothEntity
    {
        public int OrdinalNumber { get; set; }
        public TollStationEntity TollStation { get; set; }
        public PrinterEntity RecieptPrinter { get; set; }
        public PrinterEntity TicketPrinter { get; set; }
        public SemaphoreEntity Semahore { get; set; }
        public RampEntity Ramp { get; set;}
        public ScannerEntity TagScanner { get; set;} 
        public ScannerEntity LicensePlateScanner { get; set; }

        public TollBoothEntity()
        {

        }

        public TollBoothEntity(int ordinalNumber, TollStationEntity tollStation,
                         PrinterEntity recieptPrinter, SemaphoreEntity semaphore, RampEntity ramp,
                         ScannerEntity tagScanner, ScannerEntity licensePlateScanner)
        {
            OrdinalNumber = ordinalNumber;
            TollStation = tollStation;
            RecieptPrinter = recieptPrinter;
            Semahore = semaphore;
            Ramp = ramp;
            TagScanner = tagScanner;
            LicensePlateScanner = licensePlateScanner;
        }


    }
}
