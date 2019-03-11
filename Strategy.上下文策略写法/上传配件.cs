using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy.Common;

namespace Strategy.上下文策略写法
{
    public class 上传配件 : IStrategy
    {
        public override TaskType CommandType => TaskType.上传配件;

        public override void DoStrategyWork(StrategyContext strategyContext)
        {
            Console.Write("执行上传配件业务 ");
            Console.WriteLine("我是可变参数：" + strategyContext.pars);
        }
    }
}
