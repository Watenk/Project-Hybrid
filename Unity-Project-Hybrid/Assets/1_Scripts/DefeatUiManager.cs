using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatUiManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
