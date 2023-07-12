using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleToggle : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private Image images1;
    [SerializeField] private Image images2;
    [SerializeField] private Image images3;
    [SerializeField] private Image images4;
    [SerializeField] private Image images5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ToggleAllOff", 1);
        images1.transform.gameObject.SetActive(false);
        images2.transform.gameObject.SetActive(false);
        images3.transform.gameObject.SetActive(false);
        images4.transform.gameObject.SetActive(false);
        images5.transform.gameObject.SetActive(false);
    }
    
            
           
            
    public void OnToggleChange1(Toggle toggle)
    {
        // 토글 X와 비교
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn == true)
            {
                images1.transform.gameObject.SetActive(true);
            }
            else if (toggles[i] == toggle && toggle.isOn == false)
            {
                images1.transform.gameObject.SetActive(false);
            }
            Debug.Log(toggle.gameObject.name);
        }
    }

    public void OnToggleChange2(Toggle toggle)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn == true)
            {
                images2.transform.gameObject.SetActive(true);
            }
            else if (toggles[i] == toggle && toggle.isOn == false)
            {
                images2.transform.gameObject.SetActive(false);
            }
        }
        Debug.Log(toggle.gameObject.name);
    }

    public void OnToggleChange3(Toggle toggle)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn == true)
            {
                images3.transform.gameObject.SetActive(true);
            }
            else if (toggles[i] == toggle && toggle.isOn == false)
            {
                images3.transform.gameObject.SetActive(false);
            }
            Debug.Log(toggle.gameObject.name);
        }
    }
    public void OnToggleChange4(Toggle toggle)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn == true)
            {
                images4.transform.gameObject.SetActive(true);
            }
            else if (toggles[i] == toggle && toggle.isOn == false)
            {
                images4.transform.gameObject.SetActive(false);
            }
            Debug.Log(toggle.gameObject.name);
        }
    }
    public void OnToggleChange5(Toggle toggle)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn == true)
            {
                images5.transform.gameObject.SetActive(true);
            }
            else if (toggles[i] == toggle && toggle.isOn == false)
            {
                images5.transform.gameObject.SetActive(false);
            }
            Debug.Log(toggle.gameObject.name);
        }
    }

    void ToggleAllOff()
    {
        foreach (var item in toggles)
        {
            item.isOn = false;
        }
    }

     

}
