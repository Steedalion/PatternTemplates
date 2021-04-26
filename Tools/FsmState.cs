using System;

namespace UnityToolbox.Tools
{
    public class FsmState<TStateAsEnum, TSelfClass> where TStateAsEnum : Enum
        where TSelfClass : FsmState<TStateAsEnum, TSelfClass>
    {
        protected FsmStage currentStage;
        private TSelfClass nextState;
        protected TStateAsEnum stateName;

        protected virtual void Enter()
        {
            currentStage = FsmStage.Update;
        }

        protected virtual void StateUpdate()
        {
        }

        protected virtual void Exit()
        {
            currentStage = FsmStage.Exit;
        }

        protected void ProceedToNextStage(TSelfClass next)
        {
            nextState = next;
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
            return nextState;
        }

        protected enum FsmStage
        {
            Enter,
            Update,
            Exit
        }
    }
}