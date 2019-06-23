using System;
using System.Collections.Generic;

namespace TestFramework.Utils
{
    public static class ToCompareList
    {
        public static void CompareToList(this List<string> eventNameFE, List<string> eventNameBE)
        {
            if(eventNameFE.Count != eventNameBE.Count || !new HashSet<string>(eventNameFE).SetEquals(eventNameBE))
                throw new Exception("Compared lists are different");
        }
    }
}