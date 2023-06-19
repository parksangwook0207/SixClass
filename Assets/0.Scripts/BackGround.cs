using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [System.Serializable]
    public class BGData
    {
        public Transform trans;
        public float speed;
    }

    public List<BGData> bGDatas = new List<BGData>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // trans[0].Translate(Vector3.down * Time.deltaTime * 10f);
        // trans[1].Translate(Vector3.down * Time.deltaTime * 6f);
        // trans[2].Translate(Vector3.down * Time.deltaTime * 2f);

        /* for (int i = 0; i < trans.Length; i++)
         {
             if (trans[i].localPosition.y <= -12f)
             {
                 Vector3 vec = trans[i].localPosition;
                 vec.y = 12;
                 trans[i].localPosition = vec;
             }
         }
        */
        for (int i = 0; i < bGDatas.Count; i++)
        {
            // ���ȭ�� �̵� 
            bGDatas[i].trans.Translate(Vector3.down * Time.deltaTime * bGDatas[i].speed);
            
            // ���ȭ���� ȭ�� ������ �̵��� 
            if (bGDatas[i].trans.localPosition.y <= -12f)
            {
                // ���ȭ���� ���� �̵� ��ǥ�� �̵�
                Vector3 vec = bGDatas[i].trans.localPosition;
                vec.y = 12f;
                bGDatas[i].trans.localPosition = vec;
            }
        }
    }
}
