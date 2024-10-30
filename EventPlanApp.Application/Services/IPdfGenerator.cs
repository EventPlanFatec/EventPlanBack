using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public interface IPdfGenerator
    {
        byte[] Generate(Ingresso ingresso);
    }
}
