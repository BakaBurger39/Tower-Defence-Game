using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float speed;

    public float health = 100;

    public int enemyValue = 25;

    public GameObject deathEffect;

    [Header("Slow timer")] // Will be used to set a time limit for how long enemies are slowed
    public float slowTimer = 0f;

    private Transform target;
    private int wavepointIndex = 0;

    private Turret turret;



    private void Start()
    {
        speed = startSpeed;
        target = Waypoints.points[0];


        turret = GetComponent<Turret>();
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow (float percentage)
    {
        speed = startSpeed * (1f - percentage);
        slowTimer = turret.timeSlowedFor;
    }

    void Die()
    {
        PlayerStats.Money += enemyValue;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        Destroy(gameObject);
    }

    void Update()
    {

        if (slowTimer >= 0f)
        {
            speed = startSpeed;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

}
