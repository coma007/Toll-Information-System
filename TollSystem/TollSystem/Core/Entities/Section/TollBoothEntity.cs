using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class TollBoothEntity
    {
        public int OrdinalNumber { get; set; }
        public TollStationEntity TollStation { get; set; }
        public TicketReaderEntity TickerReader { get; set; }
        public PrinterEntity RecieptPrinter { get; set; }
        public PrinterEntity TicketPrinter { get; set; }
        public SemaphoreEntity Semahore { get; set; }
        public RampEntity Ramp { get; set;}
        public ScannerEntity TagScanner { get; set;} 
        public ScannerEntity LicensePlateScanner { get; set; }

        public TollBoothEntity()
        {

        }

        public TollBoothEntity(int ordinalNumber, TollStationEntity tollStation, PrinterEntity ticketPrinter,
                         PrinterEntity recieptPrinter, SemaphoreEntity semaphore, RampEntity ramp,
                         ScannerEntity tagScanner, ScannerEntity licensePlateScanner)
        {
            OrdinalNumber = ordinalNumber;
            TollStation = tollStation;
            TicketPrinter = ticketPrinter;
            RecieptPrinter = recieptPrinter;
            Semahore = semaphore;
            Ramp = ramp;
            TagScanner = tagScanner;
            LicensePlateScanner = licensePlateScanner;
        }

        public TollBoothEntity(Tollbooth tollbooth, TollStationEntity station, PrinterEntity recieptPrinter,
                               PrinterEntity ticketPrinter, SemaphoreEntity semaphore,
                               RampEntity ramp, ScannerEntity tagScanner,
                               ScannerEntity licensePlateScanner)
        {
            OrdinalNumber = (int)tollbooth.Ordinalnumber;
            TollStation = station;
            RecieptPrinter = recieptPrinter;
            TicketPrinter = ticketPrinter;
            Semahore = semaphore;
            Ramp = ramp;
            TagScanner = tagScanner;
            LicensePlateScanner = licensePlateScanner;
        }


    }
}
