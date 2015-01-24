using UnityEngine;
using System.Collections;
public class ActionTracker : MonoBehaviour {
    
    void OnCollisionEnter2D(Collision2D something)
    {
        TouchLog touchLog = new TouchLog(gameObject.name, something.gameObject.name, something.gameObject.tag, Time.frameCount);
        GameState.submitTouchLog(touchLog);
    }
}
