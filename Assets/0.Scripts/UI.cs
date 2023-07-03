using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] private TMP_Text text;
    [SerializeField] private Image hpImage;
    [SerializeField] private Image mpImage;

    [SerializeField] private TMP_Text hptxt;
    [SerializeField] private TMP_Text mptxt;

    int score;

    int curHp = 100;
    int maxHp = 100;

    int curMp = 50;
    int maxMp = 50;

    public int SetScore
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            text.text = value.ToString();
        }
    }

    private void Start()
    {
        instance = this;

        float value = curHp / maxHp;
        hpImage.fillAmount = value;
        hptxt.text = $"{(int)(value * 100f)}%";

    }
    private void Update()
    {
        // HP
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Random.Range(0, 10) < 10)
            {
                curHp += Random.Range(5, 10);
            }
            else
            {
                curHp -= Random.Range(5, 10);
            }
            float value = curHp / maxHp;
            hpImage.fillAmount = value;
            hptxt.text = $"{(int)(value * maxHp)}%";
        }
        /*if (Input.GetKeyDown(KeyCode.H))
        {
            float value = curHp / maxHp;
            hpImage.fillAmount = value;
            hptxt.text = $"{(int)(value * 100f)}%";
        }
        */
        // MP
        /*if (Input.GetKeyDown(KeyCode.J))
        {
            mpImage.fillAmount += Time.deltaTime * 3;
            mp += 1;
            mptxt.text = $"{mp}/100";
            
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            mpImage.fillAmount -= Time.deltaTime * 3;
            mp -= 1;
            mptxt.text = $"{mp}/100";
        }
        */
    }

}
