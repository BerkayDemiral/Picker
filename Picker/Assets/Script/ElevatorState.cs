using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorState : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private Animator BarrierArea;

    public void LiftBarrierRod()
    {
        BarrierArea.Play("LiftBarrierRod");
    }

    public void Finish()
    {
        _GameManager.PickerMoveState = true;
    }
}
