using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float hp;
}

public abstract class Enemy : MonoBehaviour
{
    protected EnemyData data = new EnemyData();

    protected SpriteAnimation sa;
    [SerializeField] protected List<Sprite> hitSprite;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * data.speed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerBullet>())
        {
            Destroy(collision.gameObject);
            Hit(collision.GetComponent<PlayerBullet>().power);
        }

        /*if (collision.GetComponent<EnemyA>())
        {
            Destroy(collision.gameObject);
        }
        */
    }

    public virtual void Init()
    {
        sa = GetComponent<SpriteAnimation>();
    }


    public void Hit(float dmg)
    {
        sa.SetSprite(hitSprite, 0.1f);
        data.hp -= dmg;
        if (data.hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }



}
