using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenHands : MonoBehaviour
{
    public enum LeftOrRight
    {
        Left, Right
    }

    public LeftOrRight leftOrRight;
    // Start is called before the first frame update
    void Start() {
        StartHandBobbing();
    }

    // Update is called once per frame
    void Update() {

    }

    public void StartHandBobbing() {
        if (leftOrRight.Equals(LeftOrRight.Right)) {
            LeanTween.moveY(gameObject, transform.position.y - .012f, 2f).setEaseInOutSine().setLoopPingPong();
        }else if (leftOrRight.Equals(LeftOrRight.Left)) {
            LeanTween.moveY(gameObject, transform.position.y - .01f, 2.1f).setEaseInOutSine().setLoopPingPong();
        }
    }

    public void StopHandBobbing() {

    }
}
