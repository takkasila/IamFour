using UnityEngine;
using System.Collections;

public class selfDestroy : MonoBehaviour {

    public float delayTime;
    float timer = 0;
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > delayTime)
            Destroy(gameObject);
	
	}
}
