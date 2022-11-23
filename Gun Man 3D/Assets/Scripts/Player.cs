using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform target; //target of shooting

    [Header("Attributes")]

    public float range; //range of player shooting
    public float fireRate; //cd of shooting
    private float fireCountDown = 0f;

    [Header("AUnity Setup Fields")]

    public Transform partToRotate;//part of body to rotate player

    public float turnSpeed; //speed of rotate
    public string enemyTag = "Enemy"; //tag for target to shooting

    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //find all enemies

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        //find nearest enemy for distance to player
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy!=null && shortestDistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null) return;

        //rotation to target position
        Vector3 dir = target.position - transform.position; //point to look rotation
        Quaternion lookRotation = Quaternion.LookRotation(dir); //vector of lookrotation
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;//rotate player in turnspeed to needrotation
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); //rotation of player to rotation target

        //shoot
        if (fireCountDown<=0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null) bullet.Seek(target);
    }

}
