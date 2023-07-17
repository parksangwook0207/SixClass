using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropDown;
    // Start is called before the first frame update
    void Start()
    {
        dropDown.value = 0;
        dropDown.ClearOptions();

        string[] str = { "Q", "W", "E", "R", "T" };

        List<TMP_Dropdown.OptionData> od = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < str.Length; i++)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = str[i];
            od.Add(data);
        }

        dropDown.options = od;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
