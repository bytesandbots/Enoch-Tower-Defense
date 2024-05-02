using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BOOOOOOOOM : MonoBehaviour
{
    public GameObject BOOOOOM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject clone = Instantiate(BOOOOOM, transform.position, transform.rotation);
            Destroy (clone, 2f);
        }
        if (collision.gameObject.tag == "Suicider")
        {
            GameObject clone = Instantiate(BOOOOOM, transform.position, transform.rotation);
            Destroy(clone, 2f);
        }
    }
}
