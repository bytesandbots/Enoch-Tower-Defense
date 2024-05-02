using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingMachine : MonoBehaviour
{
    public List<GameObject> Enemies;
    public float rotSpeed = 360f;
    public GameObject projectile;
    public Transform barrel;
    public float DestroyProjectile = 5f;
    public float frequency = 0.1f;
    private float ctime;
    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        Enemies = new List<GameObject>();
    }

    public void shoot()
    {
        GameObject clone = Instantiate(projectile, barrel.position, barrel.rotation);
        Destroy(clone, DestroyProjectile);
    }

    // Update is called once per frame
    void Update()
    {
        if (ctime >= frequency)
        {
       
            canShoot = true;
        }
        else
        {
            ctime += Time.deltaTime;
        }


       if (Enemies.Count > 0)
        {
            GameObject closest = null;
            float shortest = Mathf.Infinity;
            foreach (GameObject go in Enemies)
            {
                if (Vector3.Distance(transform.position, go.transform.position) < shortest)
                {
                    shortest = Vector3.Distance(transform.position, go.transform.position);
                    closest = go;
                }
            }
            if (closest != null)
            {

                if (canShoot)
                {
                    shoot();
                    ctime = 0;
                    canShoot= false;
                }
                Vector3 dir = closest.transform.position - transform.position;
                dir.Normalize();

                float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

                Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!Enemies.Contains(collision.gameObject))
            {
                Enemies.Add(collision.gameObject); 
            }
        }
        if (collision.CompareTag("Suicider"))
        {
            if (!Enemies.Contains(collision.gameObject))
            {
                Enemies.Add(collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (Enemies.Contains(collision.gameObject))
            {
                Enemies.Remove(collision.gameObject);
            }
        }
        if (collision.CompareTag("Suicider"))
        {
            if (Enemies.Contains(collision.gameObject))
            {
                Enemies.Remove(collision.gameObject);
            }
        }
    }
}
