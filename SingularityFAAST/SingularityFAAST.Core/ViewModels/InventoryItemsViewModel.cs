﻿using SingularityFAAST.Core.Entities;
using System.Collections.Generic;

namespace SingularityFAAST.Core.ViewModels
{
    public class InventoryItemsViewModel
    {
        public IEnumerable<InventoryItem> InventoryItems { get; set; }

        public int ReturnNextInventoryNumber { get; set; } //added int property to page
    }
}
