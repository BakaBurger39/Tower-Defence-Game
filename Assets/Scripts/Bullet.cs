using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 40f;

    public int damage = 50;

    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public bool destroySelfActive;

    private Enemy enemy;
    private Turret turret;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        turret = GetComponent<Turret>();
    }

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (destroySelfActive == true)
            {
                Destroy(gameObject);
            }
            //Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target); // Makes Bullet Look at Target


    }

    void HitTarget()
    {

        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        if (destroySelfActive == true)
        {
            Destroy(gameObject);
        }
        
        //if (enemy.slowTimer == 0f) //Timer for slowing enemies
        {
            //if (turret.useSlow == true)
            {
                //enemy.slowTimer = turret.timeSlowedFor;
            }
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }


    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
