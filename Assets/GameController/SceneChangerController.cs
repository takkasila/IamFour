using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneChangerController : MonoBehaviour {

    static float stageWidth = 13.7f;
    public GameObject playerHead;
    public AudioSource stage1BGM, stage2BGM, stage3BGM;
    List<AudioSource> stageBGMs = new List<AudioSource>();

    List<Vector3> stagePos = new List<Vector3>{
        new Vector3(0, 0, -20),
        new Vector3(stageWidth * 1, -2.49f, -20),
        new Vector3(stageWidth * 2, -2.49f, -20)
    };

    void Start()
    {
        stageBGMs.Add(stage1BGM);
        stageBGMs.Add(stage2BGM);
        stageBGMs.Add(stage3BGM);

    }
	
    void Update()
    {
        float tempHeadPos = playerHead.transform.position.x + stageWidth/2f;
        int currentStage = (int)(tempHeadPos/ stageWidth);

        transform.position = stagePos[currentStage];

        if(stageBGMs[currentStage].isPlaying)
        {
            //Do nothing
        }
        else
        {
            for(int f1=0; f1< stageBGMs.Count; f1++)
            {
                if(f1 == currentStage)
                {
                    stageBGMs[f1].Play();
                }
                else
                {
                    stageBGMs[f1].Pause();

                }
            }

        }

    }
}
