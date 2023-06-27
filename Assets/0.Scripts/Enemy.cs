using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float hp;
    public float fireDelayTime;
}

public abstract class Enemy : MonoBehaviour
{
    protected EnemyData data = new EnemyData();
    

    [SerializeField] protected List<Sprite> hitSprite;
    [SerializeField] protected List<Sprite> boomSprite;
    [SerializeField] protected EnemyBulletA bullet;

    private Transform enemyPos;
    private Transform bulletParent;
    private Player p;
    private List<EnemyBulletA> bullets = new List<EnemyBulletA>();
    private List<Item> items = new List<Item>();

    protected SpriteAnimation sa;

    private float fireTimer;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * data.speed);

        if (p == null)
        {
            p = FindObjectOfType<Player>();
            return;
        }

        else if (enemyPos != null)
        {
            Vector2 vec = transform.position - p.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            enemyPos.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        // 미사일 발사
        fireTimer += Time.deltaTime;
        if (fireTimer >= data.fireDelayTime)
        {
            fireTimer = 0;
            EnemyBulletA a = Instantiate(bullet, enemyPos);
            a.transform.SetParent(bulletParent);
            bullets.Add(a);
            Destroy(a.gameObject, 3f);
        }

        // 화면 밖으로 이동하는 미사일 삭제
        foreach (var item in bullets)
        {
            if (item.transform.position.y < -6)
            {
                Destroy(item.gameObject);
                bullets.Remove(item);
            }
        }


        // 화면 밖으로 이동 시 삭제
        if (transform.position.y < -6)
        {
            // 화면 밖으로 이동하는 미사일 삭제
            DestoryBullet(null);
            // 비행기 삭제
            Destroy(gameObject);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerBullet>())
        {
            Destroy(collision.gameObject);
            Hit(collision.GetComponent<PlayerBullet>().power);
        }
    }

    public virtual void Init()
    {
        sa = GetComponent<SpriteAnimation>();
        enemyPos = transform.GetChild(0);
        p = FindObjectOfType<Player>();

        Item[] items = Resources.LoadAll<Item>("Item");

        foreach (var item in items)
        {
            this.items.Add(item);
        }
    }

    public void SetBulletParent(Transform t)
    {
        bulletParent = t;
    }

    public void DestoryBullet(EnemyBulletA bullet)
    {
        for (int i = bullets.Count - 1; i >= 0; i++)
        {
            if (bullet == null)
            {
                Destroy(bullets[i].gameObject);
                bullets.RemoveAt(i);
            }
            else 
            {
                if (bullets[i] == (bullet))
                {
                    Destroy(bullets[i].gameObject);
                    bullets.RemoveAt(i);
                    break;
                }
                
            }
        }

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
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<CircleCollider2D>());

        sa.SetSprite(boomSprite, 0.2f, () =>
        {
            for (int i = 0; i < items.Count; i++)
            {
                int rand = Random.Range(1, 101);

                string spawnStr = rand < 60 ? "Coin" : rand < 80 ? "Power" : "Boom";

                if (items[i].name == spawnStr)
                {
                    Instantiate(items[i], transform.position, Quaternion.identity);
                    break;
                }

                /* if (rand < 60 && items[i].name == "Coin")
                 {
                     break;
                 }
                 else if (rand < 80 && items[i].name == "Power")
                 {
                     break;
                 }
                 else if (rand < 80 && items[i].name == "Boom")
                 {

                 }
                */


            }
            Destroy(gameObject);
        });



    }
}
