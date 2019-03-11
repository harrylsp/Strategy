using Strategy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.上下文策略写法
{
    /// <summary>
    /// 策略类抽象类
    /// </summary>
    public abstract class IStrategy
    {
        public abstract TaskType CommandType { get; }

        public abstract void DoStrategyWork(StrategyContext strategyContext);
    }
}
