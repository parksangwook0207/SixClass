using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum Direction
    {
        patmoveplay,
        leftmove,
        rightmove
    }


    [SerializeField] private List<Sprite> patmoveplay;
    [SerializeField] private List<Sprite> leftmove;
    [SerializeField] private List<Sprite> rightmove;
    [SerializeField] private PlayerBullet bullet;
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform bulletparent;

    public float speed;
    public float fireDelayTime;
    public float fireTimer;
    public float bulletspeed;

    private SpriteAnimation sa;
    Direction dir = Direction.patmoveplay;


    // Start is called before the first frame update
    void Start()
    {
        sa = GetComponent<SpriteAnimation>();
        sa.SetSprite(patmoveplay, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        float clampX = Mathf.Clamp(transform.position.x + x, -2.31f, 2.31f);
        float clampY = Mathf.Clamp(transform.position.y + y, -4.5f, 4.5f);

        transform.position = new Vector3(clampX, clampY, 0f);

        if (x == 0 && dir != Direction.patmoveplay)
        {
            dir = Direction.patmoveplay;
            sa.SetSprite(patmoveplay, 0.2f);
        }
        else if (x > 0 && dir != Direction.rightmove)
        {
            dir = Direction.rightmove;
            sa.SetSprite(rightmove, 0.2f);
        }
        else if (x < 0 && dir != Direction.leftmove)
        {
            dir = Direction.leftmove;
            sa.SetSprite(leftmove, 0.2f);
        }
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireDelayTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerBullet b = Instantiate(bullet,playerPos);
                b.speed = bulletspeed;
                b.transform.SetParent(bulletparent);
                fireTimer = 0;
            }
        }

        


    }




}
