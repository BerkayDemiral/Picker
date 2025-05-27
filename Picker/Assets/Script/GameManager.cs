using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PickerObject;
    [SerializeField] private bool PickerMoveState;
    void Start()
    {
        PickerMoveState = true;
    }

    void Update()
    {
        if (PickerMoveState)
        {
            PickerObject.transform.position += 5f * Time.deltaTime * PickerObject.transform.forward;

            if (Time.timeScale != 0)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    PickerObject.transform.position = Vector3.Lerp(PickerObject.transform.position, new Vector3(PickerObject.transform.position.x - .1f, PickerObject.transform.position.y, PickerObject.transform.position.z), .05f);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                PickerObject.transform.position = Vector3.Lerp(PickerObject.transform.position, new Vector3(PickerObject.transform.position.x + .1f, PickerObject.transform.position.y, PickerObject.transform.position.z), .05f);
            }

        }

    }
}
