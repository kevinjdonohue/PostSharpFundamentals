using System;
using PostSharp.Aspects;

namespace PostSharpExamples.Aspects
{
    [Serializable]
    public class LogAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            LogMethodEntry(args.Method.DeclaringType.Namespace, args.Method.Name);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            LogMethodSuccess(args.Method.DeclaringType.Namespace, args.Method.Name, args.ReturnValue);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            LogMethodExit(args.Method.DeclaringType.Namespace, args.Method.Name);
        }


        public void LogMethodEntry(string methodNamespace, string methodName)
        {
            Logger.LogMessage($"{methodNamespace}.{methodName} OnEntry");
        }

        public void LogMethodSuccess(string methodNamespace, string methodName, object methodReturnValue)
        {
            Logger.LogMessage($"{methodNamespace}.{methodName} OnSuccess returns {methodReturnValue}");
        }

        public void LogMethodExit(string methodNamespace, string methodName)
        {
            Logger.LogMessage($"{methodNamespace}.{methodName} OnExit");
        }
    }
}