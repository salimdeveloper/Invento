﻿using Strado.InVento.Core.Models;

namespace Strado.InVento.Core.Interfaces
{
    public interface IInventoryRepository
    {
        Models.Inventory GetInventoryByPartsId(int partsId);
        void UpdateInventory(Inventory _inventory);
        void AddInventory(Inventory inventory);
    }
}