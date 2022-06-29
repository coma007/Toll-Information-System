using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Core.Enumerations;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class TollBoothModel : ITollBoothModel
    {
        public TollBoothEntity ModelToEntity(Tollbooth tollbooth, IDeviceRepositoryService repository,
                                             IRepositoryService<TollStationEntity> repo)
        {
            if (tollbooth.Isdeleted == 1) return null;
            List<Device> devices = repository.FindByTollBooth( (int)tollbooth.Stationid, (int)tollbooth.Ordinalnumber);
            PrinterEntity recieptPrinter = null;
            PrinterEntity ticketPrinter = null;
            SemaphoreEntity semaphore = null;
            RampEntity ramp = null;
            ScannerEntity tagScanner = null;
            ScannerEntity licensePlateScanner = null;
            foreach (Device device in devices)
            { 
                bool isDamaged = false;
                if (device.Isdamaged == 1) isDamaged = true;
                switch(device.Devicetype.ToUpper())
                {
                    case "PRINTER":
                        if (ticketPrinter == null) ticketPrinter = 
                                new PrinterEntity((int)device.Id, isDamaged);
                        else recieptPrinter = new PrinterEntity((int)device.Id, isDamaged);
                        break;
                    case "SEMAPHORE":
                        semaphore = new SemaphoreEntity(SemaphoreState.RED);
                        break;
                    case "RAMP":
                        ramp = new RampEntity(RampState.CLOSED);
                        break;
                    case "SCANNER":
                        if (tagScanner == null) tagScanner = new ScannerEntity(ScannerType.TAG);
                        else licensePlateScanner = new ScannerEntity(ScannerType.LICENSE_PLATE);
                        break;
                }
            }
            TollStationEntity tollstation = repo.GetById(tollbooth.Stationid);
            return new TollBoothEntity(tollbooth, tollstation, recieptPrinter,
                                       ticketPrinter, semaphore, ramp, tagScanner,
                                       licensePlateScanner);
        }
    }
}
