using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelCrew.Components
{
    public interface ICanAddInInventory
    {
        void AddInInventory(string id, int value);
    }
}
