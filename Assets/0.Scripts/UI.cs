using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] private TMP_Text text;

    int score;

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
        
    }

}
