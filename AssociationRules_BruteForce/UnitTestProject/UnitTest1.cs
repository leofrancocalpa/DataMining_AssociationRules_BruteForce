using System;
using System.Collections.Generic;
using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
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
            setScene0();

            foreach (ItemSet candidatoFrecuente in fIGeneration.fItemSets)
            {
                foreach (KeyValuePair<String, Item> i in candidatoFrecuente.items)
                {
                    if (i.Value.cod.Equals("BREAD"))
                    {
                        Assert.IsTrue(true);
                    }
                    if (i.Value.cod.Equals("MILK"))
                    {
                        Assert.IsTrue(true);
                    }
                    if (i.Value.cod.Equals("DIAPERS"))
                    {
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        Assert.IsTrue(false);
                    }
                }
            }
        }
    }
}
