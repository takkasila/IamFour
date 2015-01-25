using UnityEngine;
using System.Collections;

public class AttacherController : MonoBehaviour {

    bool isBeingCollided;
    public KeyCode attachKey;
    public HingeJoint2D attachJoint;
    //Collision2D collidingObject;

	// Use this for initialization
	void Start () {
	    isBeingCollided = false;
        attachJoint = gameObject.AddComponent<HingeJoint2D>();
        attachJoint.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        CheckInput();

	}

    void CheckInput() {
        if (!Input.GetKey(attachKey)) {
            Deattach();
        }
    }

    void Attach(Collision2D collidingObject) {
        if (collidingObject.gameObject.rigidbody2D != null) {

            Vector3 collisionPoint = collidingObject.contacts[0].point;
            attachJoint.connectedBody = collidingObject.gameObject.rigidbody2D;

            Transform collidingObjectTransform = collidingObject.gameObject.transform;
            Vector3 collidingObjectLocalPosition = collidingObjectTransform.InverseTransformPoint(collisionPoint);
            Transform thisTransform = this.gameObject.transform;
            Vector3 thisLocalPosition = thisTransform.InverseTransformPoint(collisionPoint);
            attachJoint.anchor = thisLocalPosition;
            attachJoint.connectedAnchor = collidingObjectLocalPosition;            

            attachJoint.enabled = true;
        }
    }

    void Deattach() {
        attachJoint.enabled = false;
    }

    // Attach to Object
    void OnCollisionEnter2D(Collision2D other) {
        /*
        if (!attachJoint.enabled && other.gameObject.tag != "Player" && other.gameObject.tag != "Untouchable") {
            isBeingCollided = true;
            collidingObject = other;
        }
        */
    }


    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Name: "+other.gameObject.name + " , Tag:" + other.gameObject.tag);
        if (Input.GetKey(attachKey) && !attachJoint.enabled) {
            Attach(other);
        }
/*
        bool stillTouching = false;
        foreach(ContactPoint2D contact in other.contacts)
        {
            if(contact.collider.gameObject.GetInstanceID() == collidingObject.gameObject.GetInstanceID())
            {
                stillTouching = true;
            }
        }
        if(!stillTouching)
            Deattach();
*/
    }
    


    // Unattach
    void OnCollisionExit2D(Collision2D other) {
    }

}
