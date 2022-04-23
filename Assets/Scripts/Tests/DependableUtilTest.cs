using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class DependableUtilTest
    {
        [Test]
        public void HasNoCyclicDependencies()
        {
            var a = new TestDependable();
            var b = new TestDependable();
            var c = new TestDependable();
            var d = new TestDependable();
            var e = new TestDependable();
            var f = new TestDependable();
            
            a.dependencies.Add(b);
            a.dependencies.Add(c);
            
            b.dependencies.Add(d);
            b.dependencies.Add(e);
            b.dependencies.Add(f);
            
            Assert.IsFalse(DependableUtil.HasCyclicDependencies(a));
        }
        
        [Test]
        public void HasCyclicDependencies()
        {
            var a = new TestDependable();
            var b = new TestDependable();
            var c = new TestDependable();
            var d = new TestDependable();
            var e = new TestDependable();
            var f = new TestDependable();
            
            a.dependencies.Add(b);
            a.dependencies.Add(c);
            
            b.dependencies.Add(d);
            b.dependencies.Add(e);
            b.dependencies.Add(f);
            
            c.dependencies.Add(a);
            
            Assert.IsTrue(DependableUtil.HasCyclicDependencies(a));
        }
        
        [Test]
        public void HasOwnCyclicDependencies()
        {
            var a = new TestDependable();
            
            a.dependencies.Add(a);

            Assert.IsTrue(DependableUtil.HasCyclicDependencies(a));
        }
        
        public class TestDependable : IDependable
        {
            public List<IDependable> dependencies = new List<IDependable>();
            public IEnumerable<IDependable> GetDirectDependencies()
            {
                return dependencies;
            }

        }
    }
}