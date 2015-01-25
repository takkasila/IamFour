using UnityEngine;
using System.Collections;

public class CoffePotController : MonoBehaviour {

    public Rigidbody2D rigid;
	
    void OnCollisionEnter2D(Collision2D something)
    {
        if(something.gameObject.tag == "Player")
        {
            rigid.isKinematic = false;
        }
    }
}
