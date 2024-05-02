using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public Transform Path;
    public float speed = 2f;
    public float rotSpeed = 360;
    public GameObject Explosion;
    private int CurrentPoint;
    private Vector3 destination;
    private float oldSpeed;
    // Start is called before the first frame update
    void Start()
    {
        destination = Path.GetChild(CurrentPoint).position;
        oldSpeed = speed;
    }

    IEnumerator freeeeeeze()
    {
        speed = 0f;
        yield return new WaitForSeconds(1f);
        speed = oldSpeed;
    }
    public void BrainFreeze()
    {
        StartCoroutine("freeeeeeze");
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            CurrentPoint++;
            if (CurrentPoint >= Path.childCount)
            {
                GameObject Explosionclone = Instantiate(Explosion, gameObject.gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(Explosionclone, 1);
            }
            else
            {
                destination = Path.GetChild(CurrentPoint).position;
            }
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
            Vector3 dir = destination - transform.position;
            dir.Normalize();

            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
    }
}
