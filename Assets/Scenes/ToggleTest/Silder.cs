using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Silder : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image image;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueUPDown()
    {
        image.color = new Color(1, 1, 1,slider.minValue/ slider.maxValue);        
    }
}
