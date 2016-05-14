using UnityEngine;
using System;
using System.Collections;

public class ShotImpactedState : TurnState
{
    float timeInState;

    public ShotImpactedState(TurnStateMachine machine) : base(machine, State.ShotImpacted)
    {
    }

    public override void OnEnter()
    {
        timeInState = 0.0f;
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate(Tank currentTank)
    {
        // TODO: This should wait for the explosion to finish and for all tanks to stop moving.
        // At some point that means we'll need access to all of the tanks, or to a class that
        // knows about all of the tanks.
        // For now, we'll just wait a second, and then move on.

        timeInState += Time.deltaTime;

        if (timeInState > 1.0f)
        {
            machine.ChangeStateDeferred(State.EndOfTurn);
        }
    }
}
