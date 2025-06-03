using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickerEndZone"))
        {
            _GameManager.ReachedEndZone();
        }
    }
}
