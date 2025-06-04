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
    public GameObject[] Balls;
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PickerObject;
    [SerializeField] private GameObject BallControlObject;
    public bool PickerMoveState;

    int ThrownBallCount;
    int TotalCheckPoint;
    int ActiveCheckPointIndex;

    [SerializeField] private List<BallAreaLogic> _BallAreaLogics = new List<BallAreaLogic>();

    void Start()
    {
        PickerMoveState = true;
        for (int i = 0; i < _BallAreaLogics.Count; i++)
        {
            _BallAreaLogics[i].CountText.text = ThrownBallCount + "/" + _BallAreaLogics[i].TargetBallCount;
        }

        TotalCheckPoint = _BallAreaLogics.Count - 1;
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
        Invoke("StageControl", 2f);

        Collider[] HitColl = Physics.OverlapBox(BallControlObject.transform.position, BallControlObject.transform.localScale / 2, Quaternion.identity);

        int i = 0;
        while (i < HitColl.Length)
        {
            HitColl[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, .8f), ForceMode.Impulse);

            i++;
        }
    }

    public void UpdateBallCount()
    {
        ThrownBallCount++;
        _BallAreaLogics[ActiveCheckPointIndex].CountText.text = ThrownBallCount + "/" + _BallAreaLogics[ActiveCheckPointIndex].TargetBallCount;
    }

    void StageControl()
    {
        if (ThrownBallCount >= _BallAreaLogics[ActiveCheckPointIndex].TargetBallCount)
        {
            _BallAreaLogics[ActiveCheckPointIndex].BallAreaElevator.Play("Elevator");
            foreach (var item in _BallAreaLogics[ActiveCheckPointIndex].Balls)
            {
                item.SetActive(false);
            }
            if (ActiveCheckPointIndex == TotalCheckPoint)
            {
                Debug.Log("WIN");
                Time.timeScale = 0;
            }
            else
            {
                ActiveCheckPointIndex++;
                ThrownBallCount = 0;
            }
        }
        else
        {
            Debug.Log("LOSE");
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(BallControlObject.transform.position,BallControlObject.transform.localScale);
    }*/
}