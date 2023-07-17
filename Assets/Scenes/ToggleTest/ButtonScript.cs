using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Toggle toggle27;
    [SerializeField] private Image imageID;
    [SerializeField] private Image imageNumber;
    [SerializeField] private Image imageQR;

    [SerializeField] private Image ID;
    [SerializeField] private GameObject ball;

    [SerializeField] private TMP_Text txt;

    [SerializeField] private TMP_InputField inputID;
    [SerializeField] private TMP_InputField inputPW;

    float timer = 180;

    private string id = "qwer";
    private string pw = "1234";

    // Start is called before the first frame update
    void Start()
    {
        imageID.transform.gameObject.SetActive(false);
        imageNumber.transform.gameObject.SetActive(false);
        imageQR.transform.gameObject.SetActive(false);

        ID.transform.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("autoLogin"))
        {
            toggle27.isOn = bool.Parse(PlayerPrefs.GetString("autoLogin"));
        }


    }

    private void Update()
    {
        timer -= Time.deltaTime;

        System.TimeSpan span = System.TimeSpan.FromSeconds(timer);
        //Debug.Log($"{span.Minutes}:{span.Seconds}");
        //txt.text = $"남은시간\n<color = green>{span.Minutes}:{span.Seconds}</color>초";
        txt.text = $"남은시간{span.Minutes}:{span.Seconds}초";
    }


    public void OnImageID()
    {
        imageID.transform.gameObject.SetActive(true);
        imageNumber.transform.gameObject.SetActive(false);
        imageQR.transform.gameObject.SetActive(false);
    }

    public void OnImageNumber()
    {
        imageID.transform.gameObject.SetActive(false);
        imageNumber.transform.gameObject.SetActive(true);
        imageQR.transform.gameObject.SetActive(false);
    }

    public void OnImageQR()
    {
        imageID.transform.gameObject.SetActive(false);
        imageNumber.transform.gameObject.SetActive(false);
        imageQR.transform.gameObject.SetActive(true);
    }

    public void OnID()
    {
        ID.transform.gameObject.SetActive(true);
        ball.transform.localPosition = new Vector3(112, -26);
    }
    public void OnoffID()
    {
        ID.transform.gameObject.SetActive(false);
        ball.transform.localPosition = new Vector3(79, -26);
    }

    public void OnLogin()
    {
        if (string.IsNullOrEmpty(inputID.text))
        {
            Debug.Log("아이디가 입력되지 않음");
        }
        if (string.IsNullOrEmpty(inputPW.text))
        {
            Debug.Log("비번이 입력되지 않음");
        }

        if (inputID.text != id)
        {
            Debug.Log("아이디 데이터가 없습니다.");
            return;
        }
        if (inputPW.text != pw || inputPW.text.Length <= 4)
        {
            Debug.Log("비밀번호 데이터가 없습니다.");
            return;
        }
    }

    public void OnAutoLogin(Toggle toggle)
    {
        PlayerPrefs.SetString("autoLogin", toggle.isOn.ToString());
        /*if (PlayerPrefs.HasKey("autoLogin"))
        {
            PlayerPrefs.SetString("autoLogin", toggle.isOn.ToString());
        }
        else
        {

        }
        */
    }
}
