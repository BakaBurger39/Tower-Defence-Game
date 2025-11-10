using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 40f;
    public GameObject impactEffect;
    public bool destroySelfActive;

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
    }

    void HitTarget()
    {

        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(target.gameObject);
        
        if (destroySelfActive == true)
        {
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
