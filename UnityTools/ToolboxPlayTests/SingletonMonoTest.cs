using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SingletonMonoTest
{
    [UnityTest]
    public IEnumerator SingletonMonoTestWithEnumeratorPasses()
    {
        GameObject gameObject = GameObject.Instantiate(new GameObject());
        TestSingletonMono singleton = gameObject.AddComponent<TestSingletonMono>();
        Assert.IsNotNull(singleton);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    public class TestSingletonMono: SingletonMonoBehaviour<TestSingletonMono>
    {
        
    }
}
