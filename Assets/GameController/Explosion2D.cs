using UnityEngine;
using System.Collections;

public class Explosion2D : MonoBehaviour {


    public GameObject explosionEffect;
    public float explosionForce= 1000;
    public float explosionRadius = 1000;
    public float explosionDelay = 0;
    float timer = 0;
    bool trigger = false;


	
	// Update is called once per frame
	void Update () {
        if(trigger)
        {

            timer += Time.deltaTime;
            if(timer >= explosionDelay)
            {
                Vector2 explosionPos = transform.position;
                Collider2D[] colliders2D = Physics2D.OverlapCircleAll(explosionPos, explosionRadius);
                foreach (Collider2D hit in colliders2D)
                {
                    Debug.Log("YEA");

                    if (hit && hit.rigidbody2D)
                    {
                        AddExplosionForce2D(hit.rigidbody2D, explosionForce, explosionPos, explosionRadius);

                    }
                }
                Instantiate(explosionEffect, explosionPos, Quaternion.identity);
                Destroy(gameObject);
            }
        }
	
	}
    void OnCollisionEnter2D(Collision2D something)
    {
        if(something.gameObject.tag == "Player")
        {
            trigger = true;
        }
    }

    public static void AddExplosionForce2D(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var dir = (body.transform.position - expPosition);
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }

        body.AddForce(dir.normalized * expForce * calc);
    }
}
