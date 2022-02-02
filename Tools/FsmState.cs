using System;

namespace UnityToolbox.Tools
{
    public class FsmState<TSelfClass,TStateAsEnum> where TStateAsEnum : Enum
        where TSelfClass : FsmState<TSelfClass, TStateAsEnum>
    {
        public FsmStage currentStage { get; private set; }
        private TSelfClass nextStateStored;
        public TStateAsEnum stateName { get; protected set; }

        protected virtual void Enter()
        {
            currentStage = FsmStage.Update;
        }

        protected virtual void StateUpdate()
        {
        }

        protected virtual void Exit()
        {
            currentStage = FsmStage.Enter;
            //reset state
        }

        protected void ProceedToNextState(TSelfClass next)
        {
            nextStateStored = next;
            currentStage = FsmStage.Exit;
        }

        protected void Initialize()
        {
            currentStage = FsmStage.Enter;
        }

        public TSelfClass Process()
        {
            if (currentStage == FsmStage.Enter) Enter();
            if (currentStage == FsmStage.Update) StateUpdate();
            if (currentStage != FsmStage.Exit) return (TSelfClass) this;
            Exit();
            return nextStateStored;
        }

        public enum FsmStage
        {
            Enter,
            Update,
            Exit
        }
    }
}