using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject healthBar;
    public float TESTFILLAMOUNT;
    // Start is called before the first frame update
    void Start()
    {
        SetHealthBar(.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //just for testing
        SetHealthBar(TESTFILLAMOUNT);
    }

    /// <summary>
    /// fillAmount between 0 and 1, 0 empty, 1 full;
    /// </summary>
    /// <param name="fillAmount"></param>
    public void SetHealthBar(float fillAmount) {
        healthBar.GetComponent<Image>().fillAmount = fillAmount;
    }

    public void ChangeHealthBarColour(Color colorChange) {
        healthBar.GetComponent<Image>().color = colorChange;
    }
}