namespace Strado.InVento.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBrandsRepository Brands { get; }
        ICategoriesRepository Categories { get;  }
        IPartsRepository Parts { get; }
        ISupplierRepository Suppliers { get; }
        IPartsWithdrawHistoryRepository PartsWithdrawHistories { get; }
        IPartsPurchaseRecordsReposiroty PartsPurchaseRecords { get; }
        IInventoryRepository Inventory { get; }
        IAddressRepository Addresses { get; }

        void Complete();
    }
}
