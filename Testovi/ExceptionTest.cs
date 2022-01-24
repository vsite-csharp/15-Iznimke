using System;
using System.Reflection;

namespace Vsite.CSharp.Iznimke.Testovi
{
    struct ExceptionHandlingInfo
    {
        public ExceptionHandlingInfo(ExceptionHandlingClauseOptions clauseOptions, Type catchType = null)
        {
            ClauseOptions = clauseOptions;
            CatchType = catchType;
        }

        public readonly ExceptionHandlingClauseOptions ClauseOptions;
        public readonly Type CatchType;
    }

    class ExceptionTest
    {
        public static bool CheckExceptionHandling<T>(string imeMetode, ExceptionHandlingInfo[] blokoviIznimke)
        {
            MethodInfo mi = typeof(T).GetMethod(imeMetode, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (mi == null)
                return false;
            MethodBody mb = mi.GetMethodBody();

            if (mb.ExceptionHandlingClauses.Count != blokoviIznimke.Length)
                return false;

            for (int i = 0; i < mb.ExceptionHandlingClauses.Count; ++i)
            {
                if (mb.ExceptionHandlingClauses[i].Flags != blokoviIznimke[i].ClauseOptions)
                    return false;
                if (mb.ExceptionHandlingClauses[i].Flags == ExceptionHandlingClauseOptions.Clause && mb.ExceptionHandlingClauses[i].CatchType != blokoviIznimke[i].CatchType)
                    return false;
            }
            return true;
        }

    }
}
