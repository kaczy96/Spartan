using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float TimeNeededToJumpDown;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            TimeNeededToJumpDown = 0.5f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if(TimeNeededToJumpDown <= 0)
            {
                effector.rotationalOffset = 180f;
            }
            else
            {
                TimeNeededToJumpDown -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0f;
        }
    }
}
