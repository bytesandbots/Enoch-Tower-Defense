using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float overallhealth = 10;
    private float currenthealth;
    public GameObject Explosion;
    public float Gain = 5;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = overallhealth;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            takedamage(6);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "Fire")
        {
            takedamage(8);
        }
        if (collision.gameObject.tag == "Ice")
        {
            takedamage(1);
            GetComponent<EnemyPath>().BrainFreeze();
        }
        if (collision.gameObject.tag == "Snipe")
        {
            takedamage(10);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Grenediar")
        {
            takedamage(10);
            Destroy(collision.gameObject);
        }
    }
    public void takedamage(float damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            GameObject Explosionclone = Instantiate(Explosion, gameObject.gameObject.transform.position, Quaternion.identity);
            GameObject.FindObjectOfType<MoneyManager>().GainMoney(Gain);
            Destroy(gameObject);
            Destroy(Explosionclone, 1);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }


}
