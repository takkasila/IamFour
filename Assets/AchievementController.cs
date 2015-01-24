using UnityEngine;
using System.Collections;

public class AchievementController : MonoBehaviour {

    bool isStart = false;

	// Use this for initialization
	void Start () {
	    isStart = true;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}

class AbstractAchievement
{
    GameState gameState;
    virtual bool IsEarned() = 0;
    virtual string GetName() = 0;
};
