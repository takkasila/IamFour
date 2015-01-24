using UnityEngine;
using System.Collections;

public class AttacherController : MonoBehaviour {

    bool isBeingCollided;
    public KeyCode attachKey;
    public HingeJoint2D attachJoint;
    Collision2D collidingObject;

	// Use this for initialization
	void Start () {
	    isBeingCollided = false;
        attachJoint = gameObject.AddComponent<HingeJoint2D>();
        attachJoint.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (isBeingCollided) {
            CheckInput();   
        }

	}

    void CheckInput() {
        if (Input.GetKey(attachKey)) {
            Attach();
        }
        else if (Input.GetKeyUp(attachKey)) {
            Deattach();
        }
    }

    void Attach() {
        if (!attachJoint.enabled) {
            attachJoint.enabled = true;

            Vector3 collisionPoint = collidingObject.contacts[0].point;
            attachJoint.connectedBody = collidingObject.gameObject.rigidbody2D;

            Transform collidingObjectTransform = collidingObject.gameObject.transform;
            Vector3 collidingObjectLocalPosition = collidingObjectTransform.InverseTransformPoint(collisionPoint);
            Transform thisTransform = this.gameObject.transform;
            Vector3 thisLocalPosition = thisTransform.InverseTransformPoint(collisionPoint);
            attachJoint.anchor = thisLocalPosition;
            attachJoint.connectedAnchor = collidingObjectLocalPosition;            
        }
    }

    void Deattach() {
        attachJoint.enabled = false;
    }

    // Attach to Object
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Untouchable") {
            isBeingCollided = true;
            collidingObject = other;
        }
    }

    // Unattach
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Untouchable") {
            if (!attachJoint.enabled) {
                isBeingCollided = false;   
            }
        }
    }

}
