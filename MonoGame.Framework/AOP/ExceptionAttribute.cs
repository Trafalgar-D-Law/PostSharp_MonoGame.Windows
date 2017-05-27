using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PostSharp.Aspects;
using PostSharp;
using System.Reflection;
using PostSharp.Reflection;

namespace Microsoft.Xna.Framework.AOP
{
    [Serializable]
    public class ExceptionAttribute : OnExceptionAspect
    {
        //当异常发生时
        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("________________________使用PostSharp______________________________________________________");
            Console.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")); ;
            Console.WriteLine("异常类名：" + args.Method.DeclaringType.FullName);
            Console.WriteLine("异常方法：" + args.Method.Name);
            Console.WriteLine("异常信息：" + args.Exception.ToString());
            args.FlowBehavior = FlowBehavior.Continue;
        }

        //需要拦截的异常类型为ArgumentException
        public override Type GetExceptionType(System.Reflection.MethodBase targetMethod)
        {
            return typeof(ArgumentException);
        }
    }
}
