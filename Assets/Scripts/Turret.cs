using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Lazer")]

    public Material lazerMaterial;

    public int damageOverTime = 30;

    public bool useLazer = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;

    [Header("Use Slow")]
    public bool useSlow = false;
    public float slowPercentage = .5f;


    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

    Enemy nearestEnemy = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //Adjust this to change the time it takes for cannon to lock onto new target
    }

    void UpdateTarget()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        float shortestDistance = Mathf.Infinity;
        

        foreach (Enemy enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (enemy != nearestEnemy)
            {
                enemy.isSlowed = false;
                Debug.Log("no longer slowed");

            }

        }
        if (targetEnemy != null && shortestDistance > range)
        {
            targetEnemy = null;
        }
        if (targetEnemy == null)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.isSlowed = false;
                
                
            }
        }
        
                
        Debug.Log(targetEnemy == null);
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            if(targetEnemy != null)
            {
                targetEnemy.isSlowed = false;

            }
            target = null;
            

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLazer)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
                    
            }
            return;
        }


        LockOnTarget();

        if (useLazer)
        {
            Laser();
            
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;

        }

    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);

        if (useSlow == true)
        {
            targetEnemy.isSlowed = true;
            targetEnemy.Slow(slowPercentage);
            
            lazerMaterial.color = new Color(0, 10, 10, 50);
        }
        else
        {
            lazerMaterial.color = new Color(35, 5, 5, 0);
        }


        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
        }
            

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        impactEffect.transform.position = target.position;
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
