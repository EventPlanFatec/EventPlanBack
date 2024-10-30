using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class PurchaseResult
    {
        public bool Success { get; }
        public string ErrorMessage { get; }

        public PurchaseResult(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
