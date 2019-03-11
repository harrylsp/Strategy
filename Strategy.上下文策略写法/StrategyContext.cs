using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.上下文策略写法
{
    public class StrategyContext
    {
        private IStrategy _strategy;

        #region 可变的上下文参数

        public string pars { get; set; }

        #endregion

        public StrategyContext(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void InvokingStrategy()
        {
            this._strategy.DoStrategyWork(this);
        }
    }
}
