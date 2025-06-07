using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballitem : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private string ItemType;
    [SerializeField] private int BonusBallIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickerEndZone"))
        {
            if (ItemType == "Propeller")
            {
                _GameManager.ShowPropeller();
                gameObject.SetActive(false);
            }
            else
            {
                _GameManager.AddBonusBall(BonusBallIndex);
                gameObject.SetActive(false);
            }
        }
    }
}
