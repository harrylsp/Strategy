using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.一般策略写法
{
    public class User
    {
        public void StartHere(IStrategy strategy)
        {
            strategy.DoStrategyWork();
        }
    }
}
