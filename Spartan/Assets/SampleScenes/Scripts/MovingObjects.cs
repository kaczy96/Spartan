using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{

    public GameObject objectToMove;
    public Transform StartPoint;
    public Transform EndPoint;

    public float movingSpeed;
    private Vector3 actualTarget;

    void Start()
    {
        actualTarget = EndPoint.position;
    }

    void Update()
    {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, actualTarget, movingSpeed * Time.deltaTime);

        if (objectToMove.transform.position == EndPoint.position)
        {
            actualTarget = StartPoint.position;
        }

        else if (objectToMove.transform.position == StartPoint.position)
        {
            actualTarget = EndPoint.position;
        }
    }

}