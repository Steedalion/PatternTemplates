using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityToolbox.Tools;

namespace Toolbox.Tools.Test
{
    public class SingletonObjectTest
    {
        [Test]
        public void ShouldNotBeNull()
        {
                Assert.IsNotNull(Singleton<Object>.Instance());
        }


        [Test]
        public void DisposeAnExistingSingletonSHouldBeNull()
        {
            Assert.IsNull(Singleton<Object>.Instance());
            
        }

        [Test]
        public void CreateTwoSignletonsShouldThrowException()
        {
            Singleton<Object>.Instance();
            Singleton<Object> singleton2 = null;
            Assert.Throws<MultipleSingleton>(() => singleton2 = new Singleton<object>());
            singleton2?.Dispose();
        }
    }
}