using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0;
    public List<Transform> waypoints;
    private int waypointIndex;
    private float range;
 
    void Start()
    {
        waypointIndex = 0;
        range = 1.0f;
    }

 
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.LookAt(waypoints[waypointIndex]);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(Vector3.Distance(transform.position,waypoints[waypointIndex].position) < range)
        {
            waypointIndex++;
            if(waypointIndex >= waypoints.Count)
            {
                waypointIndex = 0;
            }
        }
    }
}
