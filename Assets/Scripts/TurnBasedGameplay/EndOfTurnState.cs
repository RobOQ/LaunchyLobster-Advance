using UnityEngine;
using System;
using System.Collections;

public class EndOfTurnState : TurnState
{
    public EndOfTurnState(TurnStateMachine machine) : base(machine, State.EndOfTurn)
    {
    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate(Tank currentTank)
    {
    }
}
