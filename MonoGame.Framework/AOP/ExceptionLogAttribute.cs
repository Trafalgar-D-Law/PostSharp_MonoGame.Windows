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
    //[ExceptionLog]
    //截取异常并且处理异常
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    class ExceptionLogAttribute : MethodInterceptionAspect
    {
        //针对整个方法体进行包围调用添加日志和截取异常
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            Arguments arguments = args.Arguments;      //实参
            StringBuilder sb = new StringBuilder();
            ParameterInfo[] parameters = args.Method.GetParameters();    //形参
            for (int i = 0; arguments != null && i < arguments.Count; i++)
            {
                //进入的参数的值        
                sb.Append(parameters[i].Name + "=" + arguments[i] + "");
            }

            try
            {
                Console.WriteLine("进入{0}函数，参数是:{1}", args.Method.DeclaringType + args.Method.Name, sb.ToString());
                base.OnInvoke(args);
                Console.WriteLine("退出{0}函数，返回结果是:{1}", args.Method.DeclaringType + args.Method.Name, args.ReturnValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("出现异常，此方法异常信息是：{0}", ex.ToString()));
            }
        }
    }
}