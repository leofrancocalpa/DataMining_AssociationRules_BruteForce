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

        Dictionary<String, int> esperados = new Dictionary<String, int>();
        

        public void setScene0()
        {
            esperados.Add("BREAD", 4);
            esperados.Add("MILK", 4);
            esperados.Add("DIAPERS", 4);
            esperados.Add("BEER", 4);
            esperados.Add("BREAD MILK", 4);
            esperados.Add("BREAD DIAPERS", 4);
            esperados.Add("MILK DIAPERS", 4);
            esperados.Add("DIAPERS BEER", 4);

            fIGeneration = new FIGeneration(60, true);//min support del 20%
            fIGeneration.FrequentItemGeneration(3);
            
        }
        [TestMethod]
        public void TestEjemploLibro()
        {
            setScene0();
            String cadena = "";
            
            foreach (ItemSet candidatoFrecuente in fIGeneration.candidates)
            {
                foreach (KeyValuePair<String, Item> i in candidatoFrecuente.items)
                {
                    cadena += i.Key + " ";
                                      
                }

                if (esperados.ContainsKey(cadena))
                {
                  Boolean op =  candidatoFrecuente.countSupport == esperados[cadena];
                Assert.IsTrue(op);
                }

            }
            
            
        }
    }
}
