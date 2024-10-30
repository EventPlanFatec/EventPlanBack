using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<PurchaseResult> ProcessPurchaseAsync(PurchaseRequest request);
    }
}
