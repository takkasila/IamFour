using UnityEngine;
using System.Collections;

public class DoorActivated : MonoBehaviour {


        void OnCollisionEnter2D(Collider2D someShit)
        {
            Debug.Log(someShit.name);
            if(someShit.tag == "Player")
                Destroy(gameObject);
        }
}
