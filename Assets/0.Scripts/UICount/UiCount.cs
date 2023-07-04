using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCount : MonoBehaviour
{
    [SerializeField] private Image countImage;
    [SerializeField] private TMP_Text txt;


    int maxCnt = 6;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            countImage.fillAmount -= Time.deltaTime * 3f;
            float val = maxCnt;
            val -= countImage.fillAmount * Time.deltaTime * 3f;
            txt.SetText(string.Format("{0}", maxCnt * 1));
        }
    }

   
}
