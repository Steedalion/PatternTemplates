using System;

namespace Patterns
{
    public class FsmState<TStateAsEnum, TSelfClass> where TStateAsEnum : Enum where TSelfClass : FsmState<TStateAsEnum,TSelfClass>
    {
        protected FsmStage Stage;
        private TSelfClass nextState;
        protected TStateAsEnum StateName;

        protected virtual void Enter()
        {
            Stage = FsmStage.Update;
        }

        protected virtual void StateUpdate()
        {
            
        }

        protected virtual void Exit()
        {
            Stage = FsmStage.Exit;
        }

        protected void ProceedToNextStage(TSelfClass next)
        {
            nextState = next;
            Stage = FsmStage.Exit;
        }

        protected void Initialize()
        {
            Stage = FsmStage.Enter;
        }

        public TSelfClass Process()
        {
            if (Stage == FsmStage.Enter) Enter();
            if (Stage == FsmStage.Update) StateUpdate();
            if (Stage != FsmStage.Exit) return (TSelfClass) this;
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