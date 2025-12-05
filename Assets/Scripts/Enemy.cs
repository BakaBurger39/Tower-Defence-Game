using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float speed;

    public float startHealth = 100;
    public float health;

    public int enemyValue = 25;

    public bool isBoss = false;

    public Material enemyMaterial;
    public Color enemyColor;

    public bool isDead = false; // Needed this bool to prevent enemies from dieing multiple times when killed by multiple turrets at once

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    [Header("Slow timer")] // Will be used to set a time limit for how long enemies are slowed
    public float slowTimer = 0f;

    public bool isSlowed = false;

    private Transform target;
    private int wavepointIndex = 0;

    private Turret turret;

    public Transform child;
    public int rotateAmount;

    public AudioSource source;
    public AudioClip die;

    [SerializeField] private RotateAmount rotateBy;


    private void Start()
    {
        speed = startSpeed;
        target = Waypoints.points[0];

        health = startHealth;

        turret = GetComponent<Turret>();
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (isDead == false)
        {
            if (health <= 0)
            {
                isDead = true;
                source.PlayOneShot(die);
                Die();
            }
        }
        
    }

    public void Slow (float percentage)
    {
        
        speed = startSpeed * (1f - percentage);

        GetComponent<Renderer>().material.color = new Color(0, 10, 10, 50);
   
    }

    void Die()
    {
        PlayerStats.Money += enemyValue;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        WaveSpawner.enemiesAlive--;


        Destroy(gameObject);
    }

    void Update()
    {


        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            //rotateAmount = rotateBy.RotateBy;
            child.transform.Rotate(0f, -90f, 0f, Space.Self);
            GetNextWaypoint();
        }
        
        if (isSlowed == false)
        {
            speed = startSpeed;
            GetComponent<Renderer>().material.color = enemyColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(0, 10, 10, 50);
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            if (isBoss == false)
            {
                EndPath();
                return;
            }
            
        }

        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            if (isBoss == true)
            {
                SuperDeath();
                return;
            }

        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);

    }

    void SuperDeath()
    {
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;
        PlayerStats.Lives--;

        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }

}
