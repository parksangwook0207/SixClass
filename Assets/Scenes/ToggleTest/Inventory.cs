using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent; 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(prefab, parent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
