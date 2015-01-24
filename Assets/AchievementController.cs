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

abstract class AbstractAchievement
{
    protected bool isGotNotied = false;
    public abstract bool IsEarned() ;
    public abstract bool IsNotied() ;
    public abstract string GetName() ;
    public abstract string GetDescription() ;
};

class GetStartedAchievement : AbstractAchievement
{
    public override string GetName() { return "What do we do now?"; }
    public override string GetDescription() { return "Greetings to you!"; }
    public override bool IsEarned()
    {
        return false;
    }
    public override bool IsNotied() { return isGotNotied; }
};

class ControllerAchievement : AbstractAchievement
{
    public override string GetName() { return "Controller WTF!?"; }
    public override string GetDescription() { return "Good luck with your friends."; }
    public override bool IsEarned()
    {
        return false;
    }
    public override bool IsNotied() { return isGotNotied; }
};
