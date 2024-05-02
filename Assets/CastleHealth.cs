using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleHealth : MonoBehaviour
{
    public float overallhealth = 100;
    private float currenthealth;
    public GameObject Explosion;
    void Start()
    {
        currenthealth = overallhealth;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suicider")
        {
            takedamage(10);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            takedamage(5);
            Destroy(collision.gameObject);
        }
    }
    public void takedamage(float damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            GameObject Explosionclone = Instantiate(Explosion, gameObject.gameObject.transform.position, Quaternion.identity);
            Destroy(Explosionclone, 2);
            SceneManager.LoadScene("Lose Scene");
        }

    }
    // Update is called once per frame
    void Update()
    {

    }


}
