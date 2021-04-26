using System;
using NUnit.Framework;
using Patterns;
using UnityEngine;

namespace Toolbox.Tools.Test
{
    public class ObjectPoolTest
    {
        private ObjectPool<GameObject> objectPool;
        private int initialPoolLength = 10;


        [SetUp]
        public void Build()
        {
            objectPool = new ObjectPool<GameObject>(initialPoolLength);
        }

        [TearDown]
        public void DestroyObject()
        {
            objectPool = null;
        }

        [Test]
        public void ObjectsShouldNotBeInstantiatedInitially()
        {
            for (int i = 0; i < objectPool.PoolSize; i++)
            {
                Assert.Null(objectPool.GetItem(i));
            }
        }

        [Test]
        public void SetThenGetAllShouldBeTheSame()
        {
            GameObject[] gameObjects = new GameObject[objectPool.PoolSize];
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i] = new GameObject();
                objectPool.SetItem(i, gameObjects[i]);
            }

            for (int i = 0; i < objectPool.PoolSize; i++)
            {
                GameObject got = objectPool.GetItem(i);

                Assert.AreSame(gameObjects[i], got);
            }
        }

        [Test]
        public void SetAll()
        {
            for (int i = 0; i < objectPool.PoolSize; i++)
            {
                try
                {
                    objectPool.SetItem(i, new GameObject());
                }
                catch (Exception e)
                {
                    Assert.Fail("should not be an error when setting");
                }
            }
        }


        [Test]
        public void GetLength()
        {
            Assert.AreEqual(objectPool.PoolSize, initialPoolLength);
        }

        [Test]
        public void SetOutOfBoundShouldThrowAnError()
        {
            try
            {
                objectPool.SetItem(10, new GameObject());
                Assert.Fail("");
            }
            catch (Exception e)
            {
            }
        }

        [Test]
        public void GetOutOfBoundShouldThrowAnError()
        {
            try
            {
                objectPool.GetItem(10);
                Assert.Fail("");
            }
            catch (Exception e)
            {
            }
        }
    }
}