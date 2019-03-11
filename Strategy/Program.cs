using Strategy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入任务类型");

            var taskType = Convert.ToInt32(Console.ReadLine());

            Console.Write("一般写法输出：");

            // 使用大量的switch case 或者 if else 处理对应的业务
            new 一般写法.User().DoWork(taskType);

            Console.Write("\n一般策略写法输出：");

            var tType = (TaskType)Enum.Parse(typeof(TaskType), Enum.GetName(typeof(TaskType), taskType));

            // 使用一般策略
            new 一般策略写法.User().StartHere(new InstanceFactory<一般策略写法.IStrategy>().CreateInstanceByEnumName(tType));

            Console.Write("\n上下文策略写法输出：");

            // 使用上下文策略写法
            new 上下文策略写法.User(tType, "我是参数").StartHere();

            Console.ReadKey();
        }
    }
}
