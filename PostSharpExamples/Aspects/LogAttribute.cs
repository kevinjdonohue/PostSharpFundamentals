using System;
using PostSharp.Aspects;

namespace PostSharpExamples.Aspects
{
    [Serializable]
    public class LogAttribute : OnMethodBoundaryAspect
    {        
        public override void OnEntry(MethodExecutionArgs args)
        {
            Logger.LogMessage($"{args.Method.DeclaringType.Namespace}.{args.Method.Name} OnEntry");
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Logger.LogMessage($"{args.Method.DeclaringType.Namespace}.{args.Method.Name} OnSuccess returns {args.ReturnValue}");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Logger.LogMessage($"{args.Method.DeclaringType.Namespace}.{args.Method.Name} OnExit");
        }
    }
}