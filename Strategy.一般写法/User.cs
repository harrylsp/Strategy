using Strategy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.一般写法
{
    public class User
    {
        public void DoWork(int taskType)
        {
            switch (taskType)
            {
                case (int)TaskType.上传单价:
                    Console.WriteLine("执行上传单价业务");
                    break;
                case (int)TaskType.上传工单:
                    Console.WriteLine("执行上传工单业务");
                    break;
                case (int)TaskType.上传配件:
                    Console.WriteLine("执行上传配件业务");
                    break;
                case (int)TaskType.上传附件:
                    Console.WriteLine("执行上传附件业务");
                    break;
                default:
                    Console.WriteLine("无效任务类型");
                    break;
            }
        }
    }
}
