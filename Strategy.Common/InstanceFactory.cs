using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Common
{
    /// <summary>
    /// 利用反射创建具体策略类，并缓存起来
    /// </summary>
    public class InstanceFactory<T> where T : class
    {
        /// <summary>
        /// 一般处理对象缓存
        /// </summary>
        private static Dictionary<TaskType, T> dicCommands = new Dictionary<TaskType, T>();

        /// <summary>
        /// 上下文策略对象缓存
        /// </summary>
        private static Dictionary<TaskType, T> dicContextCommands = new Dictionary<TaskType, T>();
        
        /// <summary>
        /// 根据TaskType 的名称创建类对象
        /// </summary>
        /// <param name="taskType"></param>
        /// <returns></returns>
        public T CreateInstanceByEnumName(TaskType taskType)
        {
            foreach (TaskType cd in Enum.GetValues(typeof(TaskType)))
            {
                if (!dicCommands.Keys.Contains(cd))
                {
                    //(基类)Assembly.Load("当前程序集名称").CreateInstance("命名空间.子类名称"));  
                    T baseCommand = Assembly.Load(typeof(T).Assembly.GetName().Name)
                        .CreateInstance((typeof(T).Namespace + "." + cd)) as T;

                    if (baseCommand != null)
                    {
                        dicCommands.Add(cd, baseCommand);
                    }
                }

            }

            return dicCommands.FirstOrDefault(c => c.Key == taskType).Value;
        }

        /// <summary>
        /// 通过继承关系创建子类
        /// </summary>
        /// <param name="taskType"></param>
        /// <returns></returns>
        public T CreateInstanceBySubClass(TaskType taskType)
        {
            Type objType = typeof(T);
            // 获取此类型所在的程序集
            Assembly assembly = objType.Assembly;
            // 遍历获取此程序集中所有的类
            foreach (Type t in assembly.GetTypes())
            {
                // 是类并且不是抽象类并且继承IBaseCommand
                if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(objType))
                {
                    // 创建策略实例类
                    T command = Activator.CreateInstance(t) as T;

                    var key = (TaskType)Enum.Parse(typeof(TaskType), t.GetProperty("CommandType").DeclaringType.Name);

                    if (command != null && !dicCommands.ContainsKey(key))
                    {
                        dicContextCommands.Add(key, command);
                    }
                }
            }

            return dicContextCommands.FirstOrDefault(c => c.Key == taskType).Value;
        }
    }
}
