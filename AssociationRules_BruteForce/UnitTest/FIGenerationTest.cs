using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTest
{
    [TestClass]
    public class FIGenerationTest
    {
        FIGeneration fIGeneration;

        public void setScene0()
        {
            fIGeneration = new FIGeneration(60, true);//min support del 20%
            fIGeneration.loadItemSet(3);
            fIGeneration.BruteForce();
            fIGeneration.pruning();
        }
        [TestMethod]
        public void TestBruteForce()
        {
            foreach(ItemSet candidatoFrecuente in fIGeneration.fItemSets)
            {

            }
        }
    }
}
