using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryItem prefab;
    [SerializeField] private Transform parent;

    // 아이템 데이터 //////////////////////////
    string[] keys = { "weapon", "armor", "etc" };

    [SerializeField] List<Sprite> weaponS;
    [SerializeField] List<Sprite> armorsS;
    [SerializeField] List<Sprite> ectS;
    ///////////////////////////////////////////

    Dictionary<string, List<Sprite>> itemDic = new Dictionary<string, List<Sprite>>();

    // Start is called before the first frame update
    void Start()
    {
        itemDic.Add(keys[0], weaponS);
        itemDic.Add(keys[1], armorsS);
        itemDic.Add(keys[2], ectS);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
            for (int i = 0; i < 20; i++)
            {
                string key = keys[Random.Range(0, keys.Length)];
                Sprite sprite = itemDic[key][Random.Range(0, weaponS.Count)];
                InventoryItem item = Instantiate(prefab, parent);
                item.SetSprite(sprite);
            }

        //}
    }

    
}
