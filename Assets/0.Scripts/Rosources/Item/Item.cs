using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    protected float speed;
    // Start is called before the first frame update
   
    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    protected virtual void Init()
    {
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.1f);
    }


}
