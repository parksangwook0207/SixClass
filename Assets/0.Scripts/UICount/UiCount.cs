using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCount : MonoBehaviour
{
    [SerializeField] private Image countImage;
    [SerializeField] private TMP_Text txt;

    
    

    float startval = 6;

    int cnt = 1;

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
            
            float val1 = (float)cnt;
            countImage.fillAmount -= Time.deltaTime * 3f;
            
            txt.text = $"{startval - val1}";
        }
        
    }
}
