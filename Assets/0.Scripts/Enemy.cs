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
    protected SpriteAnimation sa;

    [SerializeField] protected List<Sprite> hitSprite;
    [SerializeField] protected List<Sprite> boomSprite;
    [SerializeField] protected EnemyBulletA bullet;

    private Transform enemyPos;
    private Transform bulletParent;
    private Player p;
    private List<EnemyBulletA> bullets = new List<EnemyBulletA>();

    private float fireTimer;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.down * Time.deltaTime * data.speed);

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

        // �̻��� �߻�
        fireTimer += Time.deltaTime;
        if (fireTimer >= data.fireDelayTime)
        {
            fireTimer = 0;
            EnemyBulletA a = Instantiate(bullet, enemyPos);
            a.transform.SetParent(bulletParent);
            bullets.Add(a);
            Destroy(a.gameObject, 3f);
        }

        // ȭ�� ������ �̵��ϴ� �̻��� ����
        foreach (var item in bullets)
        {
            if (item.transform.position.y < -6)
            {
                Destroy(item.gameObject);
                bullets.Remove(item);
            }
        }


        // ȭ�� ������ �̵� �� ����
        if (transform.position.y < -6)
        {
            // �̻��� ��ü ����
            foreach (var item in bullets)
            {
                Destroy(item.gameObject);
            }
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

        /*if (collision.GetComponent<EnemyA>())
        {
            Destroy(collision.gameObject);
        }
        */
    }

    public virtual void Init()
    {
        sa = GetComponent<SpriteAnimation>();
        enemyPos = transform.GetChild(0);
        p = FindObjectOfType<Player>();
    }

    public void SetBulletParent(Transform t)
    {
        bulletParent = t;
    }

    public void DestoryBullet(EnemyBulletA bullet)
    {
        for (int i = bullets.Count-1; i >= 0; i--)
        {
            if (bullets.Contains(bullet))
            {
                Destroy(bullets[i].gameObject);
                bullets.RemoveAt(i);
                break;
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
        Destroy(gameObject);
        
    }



}
