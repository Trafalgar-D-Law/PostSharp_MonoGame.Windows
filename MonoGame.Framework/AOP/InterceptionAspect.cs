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
    //[nInterceptionAspect]
        [Serializable]
        public class InterceptionAspect : LocationInterceptionAspect
        {
            //当目标类初始化属性的时候运行此函数。
            public override void RuntimeInitialize(LocationInfo locationInfo)
            {
                //打印类名、属性或字段名、字段类型
                string name = locationInfo.DeclaringType.Name + "." +
                    locationInfo.Name + " (" + locationInfo.LocationType.Name + ")"; ;
                Console.WriteLine(name);
                Console.WriteLine("RuntimeInitialize!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                System.Reflection.FieldInfo finfo = locationInfo.FieldInfo;
            }
            //设置属性的时候运行
            public override void OnSetValue(LocationInterceptionArgs args)
            {
                Console.WriteLine(args.LocationName);
                Console.WriteLine("OnSetValue!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                base.OnSetValue(args);
            }
            //获取属性的时候运行
            public override void OnGetValue(LocationInterceptionArgs args)
            {
                Console.WriteLine("OnGetValue!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                base.OnGetValue(args);
            }
        }
}
