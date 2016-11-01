﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Models
{
    
    public enum PartWithdrawlReason
    {
        [Display(Name = "To Build Product")]
        ToBuildProduct=1,

        [Display(Name = "To Repair Under Warranty")]
        ToRepairUnderWarranty =2,

        [Display(Name = "To Repair Paid")]
        ToRepairPaid =3,

        [Display(Name = "To Sale Paid")]
        ToSalePaid =4
    }
}