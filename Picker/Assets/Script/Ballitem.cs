using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballitem : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickerEndZone"))
        {
            _GameManager.ShowPropeller();
            gameObject.SetActive(false);
        }
    }
}
