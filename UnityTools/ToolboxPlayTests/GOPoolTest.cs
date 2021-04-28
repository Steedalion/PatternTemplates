using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests_PlayMode
{
    public class GOPoolTest
    {
        private GameObject gameObject;
        
         [UnityTearDown]
        public IEnumerator DestroyCreatedObjects()
        {
            GameObject.Destroy(gameObject);
            yield return null;
        }

        [UnityTest]
        public IEnumerator SingleTypeSingleObject()
        {
            GOPool goPool = BuildPoolOfSingleType(new GameObject(),1);
            yield return null;
         
            GameObject fromPool =  goPool.PopDeactivatedObjectOrReturnNull();
            
            Assert.IsNotNull(fromPool);
            yield return null;
        }
        
        [UnityTest]
         public IEnumerator SingleTypeMultipleSingleObjects()
         {
             int poolsize = 10;
            GOPool goPool = BuildPoolOfSingleType(new GameObject(),10);
            yield return null;

            for (int i = 0; i < poolsize; i++)
            {
                GameObject fromPool =  goPool.PopDeactivatedObjectOrReturnNull(); 
                Assert.IsNotNull(fromPool, "Expected not null @ "+i); 
                fromPool.SetActive(true);
            }
            
            yield return null;
        }    
         public IEnumerator SingleTypeMultipleObjects()
        {
                        int poolsize;

            GOPool goPool = BuildPoolOfSingleType(new GameObject(),1);
            yield return null;
         
            GameObject fromPool =  goPool.PopDeactivatedObjectOrReturnNull();
            
            Assert.IsNotNull(fromPool);
            yield return null;
        }

        private GOPool BuildPoolOfSingleType(GameObject type, int size)
        {
            GameObject[] singleType = new GameObject[1];
            singleType[0] = type;
            GOPool goPool = BuildPool(singleType, size);
            return goPool;
        }

        private GOPool BuildPool(GameObject[] prefabs, int poolsize)
        {
            gameObject = GameObject.Instantiate(new GameObject());
            GOPool goPool = gameObject.AddComponent<GOPool>();
            
            goPool.types = prefabs;
            goPool.poolSize = poolsize;
            return goPool;
        }

       
    }
}
