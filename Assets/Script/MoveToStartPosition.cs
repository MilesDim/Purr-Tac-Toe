using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToStartPosition : MonoBehaviour
{
     public Vector3 startPosition;

    private void Start()
    {
        transform.position = startPosition;
    }
}
