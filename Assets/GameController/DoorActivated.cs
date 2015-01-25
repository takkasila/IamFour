using UnityEngine;
using System.Collections;


public class DoorActivated : MonoBehaviour {
    public BoxCollider2D thisCollider;
    public float delay = 3;
    float timer = 0;
    bool isHitted = false;

    void Update()
    {
        if(isHitted)
        {
            timer += Time.deltaTime;
            if(timer >= delay)
            {
                thisCollider.isTrigger = true;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D something)
    {
        if(something.gameObject.tag != "Floor")
        {
            isHitted = true;
        }
    }


}
