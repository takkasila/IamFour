using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneChangerController : MonoBehaviour {

    static float stageWidth = 13.7f;
    public GameObject playerHead;

    List<Vector3> stagePos = new List<Vector3>{
        new Vector3(0, 0, -20),
        new Vector3(stageWidth * 1,-2.49f, -20),
        new Vector3(stageWidth * 2, 0, -20)
    };
	
    void Update()
    {
        float tempHeadPos = playerHead.transform.position.x + stageWidth/2f;
        int currentStage = (int)(tempHeadPos/ stageWidth);

        transform.position = stagePos[currentStage];

    }
}
