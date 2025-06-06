using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerArm : MonoBehaviour
{
    bool Rotate;

    [SerializeField] private float RotateWay;

    public void StartRotate()
    {
        Rotate = true;
    }

    void Update()
    {
        if (Rotate)
        {
            transform.Rotate(0, 0, RotateWay, Space.Self);
        }
    }
}
