﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetProjectEcommerce.Orders
{
    public enum TransactionType
    {
        ConfirmOrder,
        StartProcessing,
        FinishOrder,
        CancelOrder
    }
}