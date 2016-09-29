﻿namespace Strado.InVento.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBrandsRepository Brands { get; }
        ICategoriesRepository Categories { get;  }
        IPartsRepository Parts { get; }
        ISupplierRepository Suppliers { get; }
        IPartsSaleHistoryRepository PartsSaleHistories { get; }
        IPartsPurchaseRecordsReposiroty PartsPurchaseRecords { get; }
        IInventoryRepository Inventory { get; }

        void Complete();
    }
}
