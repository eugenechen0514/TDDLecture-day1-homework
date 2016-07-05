using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDLecture_day1_homework.Tool
{
    public class Calculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itmes"></param>
        /// <param name="numberPreGroup"> need > 0</param>
        /// <param name="accessValueFunc"></param>
        /// <returns></returns>
        public IEnumerable<int> SumByGroup<T>(IEnumerable<T> itmes, int numberPreGroup, Func<T, int> accessValueFunc)
        {
            // Parameter check
            if (itmes == null || !itmes.Any())
                return null;
            if (numberPreGroup <= 0)
                return null;
            if (accessValueFunc == null)
                return null;

            // Normal case
            var values = itmes.Select(accessValueFunc).ToList();
            var groupNumber = itmes.Count()/numberPreGroup;
            var isResidue = itmes.Count()%numberPreGroup != 0;
            
            
            var result = new List<int>();
            for (var i = 0; i < groupNumber; i++)
            {
                var sum = 0;
                for (var j = 0; j < numberPreGroup; j++)
                {
                    var index = j + i*numberPreGroup;
                    sum += values[index];
                }
                result.Add(sum);
            }

            if (isResidue)
            {
                var sum = 0;
                for (var index = groupNumber * numberPreGroup; index < values.Count; index++)
                {
                    sum += values[index];
                }
                result.Add(sum);
            }

            return result;
        }
    }
}
