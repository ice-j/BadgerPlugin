using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xam.Plugin.Badger.Abstractions
{
    public interface IBadgerService
    {
        void SetCount(int badgeCount);
        void SetAndroidContext(object Context);
        void Increment();
        void Decrement();
        void Reset();
    }
}
