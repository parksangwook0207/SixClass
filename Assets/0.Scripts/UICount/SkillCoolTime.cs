using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTime : MonoBehaviour
{
    [SerializeField] private Image countImage;
    [SerializeField] private TMP_Text txt;

    [SerializeField] private float maxTime = 6;
    float curTimer = 0;
    bool isStart = false;

    


    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            curTimer += Time.deltaTime;
            countImage.fillAmount = curTimer / maxTime;
            if (maxTime - curTimer <= 1)
            {
                txt.text = $"{(maxTime - curTimer): 0.0}";
            }
            else
            {
                txt.text = (maxTime - (int)curTimer).ToString();
            }

            if (curTimer >= maxTime)
            {
                isStart = false;
                countImage.gameObject.SetActive(false);
                txt.gameObject.SetActive(false);
            }
        }
    }
    public void OnBtn()
    {
        Debug.Log("버튼눌림");
        if (isStart == true)
        {
            return;
        }
        isStart = true;

        curTimer = 0;
        countImage.fillAmount = 0;
        txt.text = maxTime.ToString();
        countImage.gameObject.SetActive(true);
        txt.gameObject.SetActive(true);
    }
}
