using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Image imageID;
    [SerializeField] private Image imageNumber;
    [SerializeField] private Image imageQR;

    [SerializeField] private Image ID;
    [SerializeField] private GameObject ball;




    // Start is called before the first frame update
    void Start()
    {
        imageID.transform.gameObject.SetActive(true);
        imageNumber.transform.gameObject.SetActive(false);
        imageQR.transform.gameObject.SetActive(false);

        ID.transform.gameObject.SetActive(false);


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
}
