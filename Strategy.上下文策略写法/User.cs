using Strategy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.上下文策略写法
{
    public class User
    {
        private StrategyContext strategyContext;

        public User(TaskType taskType, string pars)
        {
            this.strategyContext = new StrategyContext(new InstanceFactory<IStrategy>().CreateInstanceBySubClass(taskType));
            this.strategyContext.pars = pars;
        }

        public void StartHere()
        {
            strategyContext.InvokingStrategy();
        }
    }
}
