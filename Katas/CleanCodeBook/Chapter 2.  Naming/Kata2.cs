using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanCodeBook.Chapter_2.__Naming
{

    public class SomeStuff
    {
        List<int[]> theList = new List<int[]>
            {
                new int[] {1,2,3} ,
                new int[] {4,2,3}
            };

        public List<int[]> GetThem()
        {
            List<int[]> list1 = new List<int[]>();
            foreach (int[] x in theList)
            {
                if (x[0] == 4)
                {
                    list1.Add(x);
                }
            }
            return list1;
        }
    }

    public class Kata2_Iteration_1
    {
       

       

        public void Run()
        {

        }
    }

    public class SomeStuffTests
    {
        [Fact]
        public void Launch()
        {
            var someStuff = new SomeStuff();
            var them = someStuff.GetThem();
        }
    }
}
