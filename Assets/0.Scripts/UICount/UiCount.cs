using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCount : MonoBehaviour
{
    [SerializeField] private Image countImage;
    [SerializeField] private TMP_Text txt;


    float maxCnt = 1;

    float startval = 6;



    // Start is called before the first frame update
    void Start()
    {
        txt.text = $"{startval}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            StartCoroutine("Cooltime", 6);
        }
    }

    void Cooltime(float cool)
    {
        float val += Time.deltaTime;

        txt.text = $"{startval - val}";

    }
}
