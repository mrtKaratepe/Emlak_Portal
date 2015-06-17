using Ltd.NA.Emlak.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Mocks
{
    public class DomainMocksFactory
    {
        public static House CreateHouse()
        {
            return House.Create(Guid.NewGuid(), "My Name", "My Description");
        }
    }
}
