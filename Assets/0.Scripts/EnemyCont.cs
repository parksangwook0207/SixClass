using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour
{
    [SerializeField] private EnemyA enemy;
    [SerializeField] private Transform parent;

    [SerializeField] private BoxCollider2D spawnBox;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomPosition", 2, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RandomPosition()
    {
        Vector3 pos = spawnBox.transform.position;

        // 박스 콜라이더의 값
        float sizeX = spawnBox.bounds.size.x;
        float sizeY = spawnBox.bounds.size.y;

        // 박스를 -50 50중에서 랜덤
        sizeX = Random.Range((sizeX / 2) * -1, sizeX / 2);
        sizeY = Random.Range((sizeY / 2) * -1, sizeY / 2);

        Vector3 randPos = new Vector3(sizeX, sizeY, 0f);

        Vector3 rPos = pos + randPos;
        Instantiate(enemy, rPos, Quaternion.identity, parent);
    }
}
