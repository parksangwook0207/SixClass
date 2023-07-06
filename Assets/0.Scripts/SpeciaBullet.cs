using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeciaBullet : MonoBehaviour
{
    [SerializeField] private Image sbGo;
    bool isStart = false;


    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public void OnShow()
    {
        gameObject.SetActive(true);
        Vector2 pos = transform.localPosition;
        pos.y = -Camera.main.orthographicSize;
        transform.localPosition = pos;
        isStart = true;


    }

    public void OnHide()
    {
        isStart = false;
        gameObject.SetActive(false);
        
    }
}
