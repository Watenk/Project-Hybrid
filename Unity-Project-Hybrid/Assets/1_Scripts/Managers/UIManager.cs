using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public HealthBar healthSlider;

    private Player player;

    public void Start(){
        player = GameManager.Instance.Player.GetComponent<Player>();
    }

    public void FixedUpdate(){
        //healthSlider.SetHealthBar(0.5f);
    }
}
