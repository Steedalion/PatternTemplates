using System;
using JetBrains.Annotations;
using NUnit.Framework;

namespace UnityToolbox.Tools.EditTests
{
    public class FSMTests
    {
        [Test]
        public void CreateFSM()
        {
            FsmState<MockFSM, MockStates> mock;
            mock = new FsmState<MockFSM, MockStates>();
        }

        [Test]
        public void RunOnce()
        {
            var state = new RunOnce();
            Assert.False(state.hasRun);
            state.Process();
            Assert.True(state.hasRun);
        }

        [Test]
        public void CanReuseState()
        {
            Assert.Fail();
        }
    }

    public class RunAndNext : RunOnce
    {
        private MockFSM nextState;

        public RunAndNext(MockFSM nextState)
        {
            this.nextState = nextState;
        }

        protected override void StateUpdate()
        {
            base.StateUpdate();
            ProceedToNextState(nextState);
        }
    }

    public class RunOnce : MockFSM
    {
        public bool hasRun = false;

        protected override void StateUpdate()
        {
            hasRun = true;
        }
    }

    public enum MockStates
    {
    }

    public class MockFSM : FsmState<MockFSM, MockStates>
    {
    }
}