using UnityEngine;
using System.Collections;

public class SceneChangerController : MonoBehaviour {

	
        void OnTriggerEnter2D(Collider2D someShit)
        {
            if(someShit.tag == "Player") {
                Destroy(gameObject);
                Application.LoadLevel(1);
            }
                
        }
}
