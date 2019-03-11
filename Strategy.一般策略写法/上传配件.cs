using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.一般策略写法
{
    public class 上传配件 : IStrategy
    {
        public void DoStrategyWork()
        {
            Console.WriteLine("执行上传配件业务");
        }
    }
}
