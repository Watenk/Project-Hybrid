using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public List<GameObject> healthBars = new List<GameObject>();

    private GameObject activeHealthBar;
    private Player player;

    //---------------------------------------

    void Start(){
        player = GameManager.Instance.Player.GetComponent<Player>();

        foreach (GameObject healthBar in healthBars){
            healthBar.SetActive(false);
        }

        activeHealthBar = healthBars[5];
    }

    void FixedUpdate(){
        SetHealthBar(player.Health);
    }

    public void SetHealthBar(int amount) {

        if (activeHealthBar != null){
            activeHealthBar.SetActive(false);
            healthBars[amount].SetActive(true);
        }
    }
}
