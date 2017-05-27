using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PostSharp.Aspects;
using PostSharp;
using System.Reflection;
using PostSharp.Reflection;

namespace Microsoft.Xna.Framework
{
    //日志特性截取类,[Logs]
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]    //只对AttributeTargets.Method有效，可以多个实例，且可以被继承
    class LogsAttribute : OnMethodBoundaryAspect
    {
        /// <summary>
        /// 入口参数信息
        /// </summary>
        public string EntryText { get; set; }    //

        /// <summary>
        /// 出口参数信息
        /// </summary>
        public string ExitText { get; set; }    //

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionText { get; set; }

        //进入函数时输出函数的输入参数
        public override void OnEntry(MethodExecutionArgs eventArgs)
        {
            Console.WriteLine("Entry!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Arguments arguments = eventArgs.Arguments;   //实参
            StringBuilder sb = new StringBuilder();
            ParameterInfo[] parameters = eventArgs.Method.GetParameters();  //形参
            for (int i = 0; arguments != null && i < arguments.Count; i++)
            {
                //进入的参数的值
                sb.Append(parameters[i].Name + "=" + arguments[i] + " ");
            }
            string message = string.Format("{0}.{1} Method. The Entry Arg Is：{2}",
                eventArgs.Method.DeclaringType.FullName, eventArgs.Method.Name, sb.ToString());
            Console.WriteLine(message);
        }

        //退出函数时的函数返回值
        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            Console.WriteLine("Exit!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(string.Format("{0}.{1} Method. The Result Is：{2}",
                eventArgs.Method.DeclaringType.FullName, eventArgs.Method.Name, eventArgs.ReturnValue.ToString()));
        }

        //函数发生异常时记录异常信息
        public override void OnException(MethodExecutionArgs eventArgs)
        {
            Console.WriteLine("Error!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(string.Format("{0}.{1} Method. The Exception Is：{2}",
                eventArgs.Method.DeclaringType.FullName, eventArgs.Method.Name, eventArgs.Exception.Message));

        }
    }

    ////[Exception]
    ////截取异常并且处理异常
    //[Serializable]
    //[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //class ExceptionAttribute : MethodInterceptionAspect
    //{
    //    //调用本函数时截取异常
    //    public override void OnInvoke(MethodInterceptionArgs args)
    //    {
    //        try
    //        {
    //            base.OnInvoke(args);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(string.Format("此方法异常信息是：{0}", ex.ToString()));
    //        }
    //    }
    //}


 


 


}
