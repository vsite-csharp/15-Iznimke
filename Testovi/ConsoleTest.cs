using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.IO;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public abstract class ConsoleTest
    {
        protected class ConsoleTestWriter : StringWriter
        {
            public override void WriteLine(string text)
            {
                output.Enqueue(text);
            }

            public override void WriteLine(int number)
            {
                output.Enqueue(number);
            }

            public override void WriteLine(double number)
            {
                output.Enqueue(number);
            }

            public override void WriteLine(object obj)
            {
                output.Enqueue(obj);
            }

            public string GetString()
            {
                return (string)output.Dequeue();
            }

            public int GetInt()
            {
                return (int)output.Dequeue();
            }

            public double GetDouble()
            {
                return (double)output.Dequeue();
            }

            public object GetObject()
            {
                return output.Dequeue();
            }

            public bool IsEmpty
            {
                get { return output.Count == 0; }
            }

            public int Count
            {
                get { return output.Count; }
            }

            Queue output = new Queue();
        }

        protected ConsoleTestWriter cw = null;
        protected ConsoleTestWriter ew = null;

        [TestInitialize()]
        public virtual void Initialize()
        {
            cw = new ConsoleTestWriter();
            Console.SetOut(cw);
            ew = new ConsoleTestWriter();
            Console.SetError(ew);
        }

        [TestCleanup()]
        public virtual void Cleanup()
        {
            cw.Dispose();
            ew.Dispose();
        }
    }
}
