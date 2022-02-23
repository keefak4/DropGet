using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HymanDistance : MonoBehaviour
{
     [SerializeField] private Transform start;
    [SerializeField] private Transform end;



    private float arriveTime = 10f;


    void Update()
    {
        transform.position = Vector3.Lerp(start.position, end.position, Mathf.PingPong(Time.time / arriveTime, 1f));
    }
}
