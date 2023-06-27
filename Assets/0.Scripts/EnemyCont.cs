using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform bulletparent;

    [SerializeField] private BoxCollider2D spawnBox;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomPosPosition", 2f, 4f);
        //StartCoroutine(SpawnEnemy());
        //StartCoroutine("SpawnEnemy");
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
        Vector3 randdomPos = new Vector3(sizeX, sizeY, 0f);

        Vector3 randPos = pos + randdomPos;
        int rand = Random.Range(0, enemy.Count);
        Enemy e = Instantiate(enemy[rand], randPos, Quaternion.identity, parent);
        e.SetBulletParent(bulletparent);
    }

    IEnumerator SpawnEnemy1()
    {
        yield return new WaitForSeconds(2f);
        RandomPosition();
        yield return StartCoroutine("SpawnEnemy");
    }


    /*IEnumerator SpawnEnemy()
    {
        RandomPosition();
        yield return new WaitForSeconds(1f);
       //StartCoroutine("SpawnEnemy");
    }
    */
}
