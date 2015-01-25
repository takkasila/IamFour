using UnityEngine;
using System.Collections;

public struct BodyPartJoint2D
{
    public HingeJoint2D hinge;
    public KeyCode keyCW, keyCCW;

    public BodyPartJoint2D (HingeJoint2D j, KeyCode cw, KeyCode ccw)
    {
        hinge = j;
        keyCW = cw;
        keyCCW = ccw;
    }
}

public class PlayerController : MonoBehaviour {

    public float rotationSpeed = 400;

    // Left Arm

    public KeyCode leftArmGrab      = KeyCode.E;
    public HingeJoint2D leftUpperArmJoint;
    public KeyCode leftUpperArmCW   = KeyCode.A;
    public KeyCode leftUpperArmCCW  = KeyCode.Q;
    public HingeJoint2D leftLowerArmJoint;
    public KeyCode leftLowerArmCW   = KeyCode.S;
    public KeyCode leftLowerArmCCW  = KeyCode.W;

    public BodyPartJoint2D leftUpperArm;
    public BodyPartJoint2D leftLowerArm;

    // Right Arm

    public KeyCode rightArmGrab     = KeyCode.LeftBracket;
    public HingeJoint2D rightUpperArmJoint;
    public KeyCode rightUpperArmCW  = KeyCode.L;
    public KeyCode rightUpperArmCCW = KeyCode.O;
    public HingeJoint2D rightLowerArmJoint;
    public KeyCode rightLowerArmCW  = KeyCode.Semicolon;
    public KeyCode rightLowerArmCCW = KeyCode.P;

    public BodyPartJoint2D rightUpperArm;
    public BodyPartJoint2D rightLowerArm;

    // Left Leg

    public KeyCode leftLegGrab      = KeyCode.B;
    public HingeJoint2D leftUpperLegJoint;
    public KeyCode leftUpperLegCW   = KeyCode.C;
    public KeyCode leftUpperLegCCW  = KeyCode.D;
    public HingeJoint2D leftLowerLegJoint;
    public KeyCode leftLowerLegCW   = KeyCode.V;
    public KeyCode leftLowerLegCCW  = KeyCode.F;

    public BodyPartJoint2D leftUpperLeg;
    public BodyPartJoint2D leftLowerLeg;

    // Right Leg

    public KeyCode rightLegGrab     = KeyCode.Comma;
    public HingeJoint2D rightUpperLegJoint;
    public KeyCode rightUpperLegCW  = KeyCode.N;
    public KeyCode rightUpperLegCCW = KeyCode.H;
    public HingeJoint2D rightLowerLegJoint;
    public KeyCode rightLowerLegCW  = KeyCode.M;
    public KeyCode rightLowerLegCCW = KeyCode.J;

    public BodyPartJoint2D rightUpperLeg;
    public BodyPartJoint2D rightLowerLeg;


	// Use this for initialization
	void Start () {
        leftUpperArm = new BodyPartJoint2D(leftUpperArmJoint, leftUpperArmCW, leftUpperArmCCW);
        leftLowerArm = new BodyPartJoint2D(leftLowerArmJoint, leftLowerArmCW, leftLowerArmCCW);

        rightUpperArm = new BodyPartJoint2D(rightUpperArmJoint, rightUpperArmCW, rightUpperArmCCW);
        rightLowerArm = new BodyPartJoint2D(rightLowerArmJoint, rightLowerArmCW, rightLowerArmCCW);

        leftUpperLeg = new BodyPartJoint2D(leftUpperLegJoint, leftUpperLegCW, leftUpperLegCCW);
        leftLowerLeg = new BodyPartJoint2D(leftLowerLegJoint, leftLowerLegCW, leftLowerLegCCW);

        rightUpperLeg = new BodyPartJoint2D(rightUpperLegJoint, rightUpperLegCW, rightUpperLegCCW);
        rightLowerLeg = new BodyPartJoint2D(rightLowerLegJoint, rightLowerLegCW, rightLowerLegCCW);
	}
	
	// Update is called once per frame
	void Update () {
	    CheckInput();    
	}

    // Body Part Updater
    void CheckInput() {
        BodyPartMovement(leftUpperArm);
        BodyPartMovement(leftLowerArm);

        BodyPartMovement(rightUpperArm);
        BodyPartMovement(rightLowerArm);

        BodyPartMovement(leftUpperLeg);
        BodyPartMovement(leftLowerLeg);

        BodyPartMovement(rightUpperLeg);
        BodyPartMovement(rightLowerLeg);
    }

    // Handle every part movement
    void BodyPartMovement(BodyPartJoint2D joint) {
        RotateBodyPart(joint.hinge, Input.GetKey(joint.keyCW) ? rotationSpeed : (Input.GetKey(joint.keyCCW) ? -rotationSpeed : 0));
    }

    // Rotate Part
    void RotateBodyPart(HingeJoint2D bodyPartJoint, float rotateSpeed) {
        if (rotateSpeed == 0.0f) {
            bodyPartJoint.useMotor = false;
        }
        else {
            JointMotor2D motor = bodyPartJoint.motor;
            motor.motorSpeed = 0;
            bodyPartJoint.motor = motor;
            motor = bodyPartJoint.motor;
            motor.motorSpeed = rotateSpeed;
            bodyPartJoint.motor = motor;   
        }
    }


}
