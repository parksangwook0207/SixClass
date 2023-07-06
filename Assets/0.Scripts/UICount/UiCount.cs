using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCount : MonoBehaviour
{/*
    [SerializeField] private Image countImage;
    [SerializeField] private TMP_Text txt;

    

    float maxCnt = 6;
    float value;
    float value1;

    bool isStart;
    */

    //[SerializeField] private Button button;
    [SerializeField] private SpeciaBullet sb;

    // Start is called before the first frame update
    void Start()
    {
        // txt.text = $"{maxCnt}";
        //for (int i = 0; i < 10; i++)
      //  {
           // button.onClick.AddListener(() => OnClick(i));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.K))
        {          
            value += Time.deltaTime;

            countImage.fillAmount = value / maxCnt;
            value1 = maxCnt - value;
            txt.text = string.Format("{0:0}", value1);

        }
        if (value1 == 1)
        {
            txt.text = string.Format("{0:0.0}", value1);
        }
        */
    }

    public void OnClick()
    {
        sb.OnShow();
        Debug.Log("¹öÆ°");
        
    }




}
