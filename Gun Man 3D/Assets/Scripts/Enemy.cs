using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Transform target;
    private int wavepointIndex = 0;
    
    private void Start()
    {
        target = WayPoints.points[wavepointIndex];
        transform.position = new Vector3(target.position.x, target.position.y,target.position.z - 0.5f);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position; //position vector
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)<=0.4f)
        {
            GetNextWaePoint();
        }
        transform.LookAt(target);
    }

    void GetNextWaePoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    }
}