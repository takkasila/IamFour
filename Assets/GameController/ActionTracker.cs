using UnityEngine;
using System.Collections;
public class ActionTracker : MonoBehaviour {
    
    void OnCollisionEnter2D(Collision2D something)
    {
        TouchLog touchLog = new TouchLog(gameObject.name, gameObject.tag, something.gameObject.name, something.gameObject.tag, Time.frameCount);
        GameState.submitTouchLog(touchLog);
    }

    void OnTriggerEnter2D(Collider2D something)
    {
        TouchLog touchLog = new TouchLog(gameObject.name, gameObject.tag, something.gameObject.name, something.gameObject.tag, Time.frameCount);
        GameState.submitTouchLog(touchLog);
    }
}
