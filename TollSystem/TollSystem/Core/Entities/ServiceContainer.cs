using TollSystem.Commands.IncomeReport;
using TollSystem.Commands.TollPayment;
using TollSystem.Commands.TollStationCreation;
using TollSystem.Core.Services;
using TollSystem.Core.UseCases;
using TollSystem.Core.UseCases.Login;

namespace TollSystem.Core.Entities
{
    public static class ServiceContainer
    {
        public static IDamageModelService DamageModelService => new DamageModelService();

        public static IDamageRepositoryService DamageRepositoryService =>
            new DamageRepositoryService(RepositoryContainer.DamageRepository);

        public static IDeviceModelService DeviceModelService => new DeviceModelService();

        public static IDeviceRepositoryService DeviceRepositoryService =>
            new DeviceRepositoryService(RepositoryContainer.DeviceRepository);

        public static IPriceModelService PriceModelService => new PriceModelService();

        public static IPriceRepositoryService PriceRepositoryService =>
            new PriceRepositoryService(RepositoryContainer.PriceRepository);

        public static IPricelistModelService PricelistModelService => new PricelistModelService();

        public static IPricelistRepositoryService PricelistRepositoryService =>
            new PricelistRepositoryService(RepositoryContainer.PricelistRepository);

        public static ISectionModelService SectionModelService => new SectionModelService();

        public static ISectionRepositoryService SectionRepositoryService =>
            new SectionRepositoryService(RepositoryContainer.SectionRepository);

        public static ITransitModelService TransitModelService => new TransitModelService();

        public static ITransitRepositoryService TransitRepositoryService =>
            new TransitRepositoryService(RepositoryContainer.TransitRepository);

        public static ITollStationModelService TollStationModelService => new TollStationModelService();

        public static ITollStationRepositoryService TollStationRepositoryService =>
            new TollStationRepositoryService(RepositoryContainer.TollStationRepository);

        public static ITollBoothModelService TollBoothModelService => new TollBoothModelService();

        public static ITollBoothRepositoryService TollBoothRepositoryService =>
            new TollBoothRepositoryService(RepositoryContainer.TollBoothRepository);

        public static ITagModelService TagModelService => new TagModelService();

        public static ITagRepositoryService TagRepositoryService => new TagRepositoryService(RepositoryContainer.TagRepository);

        public static ITicketModelService TicketModelService => new TicketModelService();

        public static ITicketRepositoryService TicketRepositoryService => new TicketRepositoryService(RepositoryContainer.TicketRepository);

        public static ITransactionModelService TransactionModelService => new TransactionModelService();

        public static ITransactionRepositoryService TransactionRepositoryService =>
            new TransactionRepositoryService(RepositoryContainer.TransactionRepository);

        public static IStaffModelService StaffModelService => new StaffModelService();

        public static IStaffRepositoryService StaffRepositoryService =>
            new StaffRepositoryService(RepositoryContainer.StaffRepository, StaffModelService, TollStationRepositoryService);

        public static IIncomeReportService IncomeReportService => new IncomeReportService(TollStationRepositoryService,
            TransitRepositoryService, TransactionRepositoryService, TollStationModelService);

        public static ILoginService LoginService => new LoginService(StaffRepositoryService);

        public static IPhysicalPaymentService PhysicalPaymentService => new PhysicalPaymentService(
            RepositoryContainer.TransitRepository, TollStationRepositoryService, RepositoryContainer.TicketRepository,
            RepositoryContainer.SectionRepository, RepositoryContainer.PricelistRepository,
            RepositoryContainer.PriceRepository, RepositoryContainer.TransactionRepository);

        public static ITollStationCreationService TollStationCreationService => new TollStationCreationService(
            RepositoryContainer.TollStationRepository, RepositoryContainer.TollBoothRepository,
            RepositoryContainer.DeviceRepository, RepositoryContainer.SectionRepository,
            RepositoryContainer.PricelistRepository, RepositoryContainer.PriceRepository, RepositoryContainer.ScannerRepository);
    }
}