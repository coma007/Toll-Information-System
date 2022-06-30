using TollSystem.Core.Services;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Entities
{
    public static class RepositoryContainer
    {
        public static ModelContext Context = new ModelContext();

        public static Repository<Tollstation> TollStationRepository =>
            new Repository<Tollstation>(Context, Context.Tollstation);

        public static ITollBoothRepository TollBoothRepository => new TollBoothRepository(Context);

        public static DeviceRepository DeviceRepository => new DeviceRepository(Context);

        public static Repository<Scanner> ScannerRepository => new Repository<Scanner>(Context, Context.Scanner);

        public static Repository<Section> SectionRepository => new Repository<Section>(Context, Context.Section);

        public static IStaffRepository StaffRepository => new StaffRepository(Context);

        public static IPricelistRepository PricelistRepository => new PricelistRepository(Context);

        public static IPriceRepository PriceRepository => new PriceRepository(Context);

        public static Repository<Salesplace> SalesplaceRepository =>
            new Repository<Salesplace>(Context, Context.Salesplace);

        public static IDamageRepository DamageRepository => new DamageRepository(Context);

        public static Repository<Ticket> TicketRepository => new Repository<Ticket>(Context, Context.Ticket);

        public static IRepository<Tag> TagRepository => new Repository<Tag>(Context, Context.Tag);

        public static ITransitRepository TransitRepository => new TransitRepository(Context);

        public static ITransactionRepository TransactionRepository => new TransactionRepository(Context);
    }
}