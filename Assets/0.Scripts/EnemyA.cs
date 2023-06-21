using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 3f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        /*if (collision.GetComponent<EnemyA>())
        {
            Destroy(collision.gameObject);
        }
        */
    }

    
}
