using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class BallAreaLogic
{
    public Animator BallAreaElevator;
    public TextMeshProUGUI CountText;
    public int TargetBallCount;
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PickerObject;
    [SerializeField] private GameObject BallControlObject;
    [SerializeField] private bool PickerMoveState;

    int ThrownBallCount;
    [SerializeField] private List<BallAreaLogic> _BallAreaLogics = new List<BallAreaLogic>();

    void Start()
    {
        PickerMoveState = true;
        _BallAreaLogics[0].CountText.text = ThrownBallCount + "/" + _BallAreaLogics[0].TargetBallCount;
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

    public void ReachedEndZone()
    {
        PickerMoveState = false;

        Collider[] HitColl = Physics.OverlapBox(BallControlObject.transform.position, BallControlObject.transform.localScale/2, Quaternion.identity);

        int i = 0;
        while (i < HitColl.Length)
        {
            HitColl[i].GetComponent<Rigidbody>().AddForce(new Vector3(0,0,.8f),ForceMode.Impulse);

            i++;
        }
        Debug.Log(i);

    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(BallControlObject.transform.position,BallControlObject.transform.localScale);
    }*/
}