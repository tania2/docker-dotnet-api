using DockerDotnetApi.Models.BinList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerDotnetApi.Managers
{
    public interface IManageBinList
    {
        IssuerInformation PaymentCardCost(string bin);
    }
}
