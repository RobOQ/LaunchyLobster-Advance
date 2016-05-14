using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public Vector3 CameraOffset;
    public Vector3 CameraRelativeRotation;

    List<Tank> tanks;
    int turnIndex;
    bool hasGameStarted;
    TurnStateMachine turnStateMachine;

    void Awake()
    {
        hasGameStarted = false;
        tanks = new List<Tank>();
        turnIndex = 0;
        turnStateMachine = new TurnStateMachine();
    }

    public void RegisterPlayer(Tank tank)
    {
        tanks.Add(tank);
    }

    public void Update()
    {
        if (!hasGameStarted)
        {
            StartTurn(turnIndex);
            hasGameStarted = true;
        }

        bool turnOver = turnStateMachine.Update(tanks[turnIndex]);

        if (turnOver)
        {
            turnIndex = (turnIndex + 1) % tanks.Count;
            StartTurn(turnIndex);
        }
    }

    public void StartTurn(int tankIndex)
    {
        Camera.main.transform.SetParent(tanks[tankIndex].UnmovableYAxis.transform);
        Camera.main.transform.localPosition = CameraOffset;
        Camera.main.transform.localRotation = Quaternion.Euler(CameraRelativeRotation);
        turnStateMachine.ChangeStateImmediate(TurnState.State.WaitingForShot);
    }
}
