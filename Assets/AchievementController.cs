using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementController : MonoBehaviour {

    bool isStart = false;
    public ArchievementNotic achievementNoti;
    List<AbstractAchievement> achievements;
    bool[] isNotied = new bool[100];

	// Use this for initialization
	void Start () {
	    isStart = true;
        //achievement = new List<AbstractAchievement>();
        for (int i=0; i<100 ; i++) isNotied[i] = false;
        achievements = new List<AbstractAchievement>{
                new ControllerAchievement(), 
                new BookAchievement(), 
                new HeadBookAchievement(), 
                new RisesAchievement(), 
                new TouchDownAchievement(), 
                new GardenerAchievement(),
                new WrongWayOutAchievement(),
                new JingleBellsAchievement(),
                new JuonAchievement(),
                new OuchAchievement(),
            };
	}
	
	// Update is called once per frame
	void Update () {
        int index = 0;
        foreach (AbstractAchievement achievement in achievements) {
            if (!isNotied[index]) {
                if (achievement.IsEarned()) {
                    isNotied[index] = true;
                    Debug.Log("Achievement Unlocked!");
                    achievementNoti.archievementUnlock(achievement.Name(), achievement.Description());
                }
            }
            index ++;
        }
	}
}

abstract class AbstractAchievement
{
    public abstract bool IsEarned();
    public abstract string Name();
    public abstract string Description();
};


class ControllerAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Controller WTF!?";
    }
    public override string Description() { 
        return "Good luck with your friends.";
    }
    public override bool IsEarned()
    {
        return false;
    }
};

class BookAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Damn! Book!";
    }
    public override string Description() { 
        return "Touch a book for the first time.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getTag() == "Book") {
                return true;
            }
        }
        return false;
    }
}

class HeadBookAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Absorbing knowledge";
    }
    public override string Description() { 
        return "Headbutted a book.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getTag() == "Book" && touched.getAuthor() == "Head") {
                return true;
            }
        }
        return false;
    }
}

class RisesAchievement : AbstractAchievement
{
    public override string Name() { 
        return "RISES!";
    }
    public override string Description() { 
        return "Get out of the bed.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getTag() == "Floor") {
                return true;
            }
        }
        return false;
    }
}

class TouchDownAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Touch down!";
    }
    public override string Description() { 
        return "Touch your own head down the floor.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getTag() == "Floor" && touched.getAuthor() == "Head") {
                return true;
            }
        }
        return false;
    }
}

class GardenerAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Gardener";
    }
    public override string Description() { 
        return "Feel the touch of nature.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getTag() == "PlantPot") {
                return true;
            }
        }
        return false;
    }
}

class WrongWayOutAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Wrong way out";
    }
    public override string Description() { 
        return "Hit the window.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getTag() == "Window") {
                return true;
            }
        }
        return false;
    }
}

class JingleBellsAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Jingle Bells";
    }
    public override string Description() { 
        return "Ring those hanging bells.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getTag() == "Bells") {
                return true;
            }
        }
        return false;
    }
}

class JuonAchievement : AbstractAchievement
{
    public override string Name() { 
        return "JU-ON";
    }
    public override string Description() { 
        return "Reach underneath bed.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getTag() == "Bed") {
                Debug.Log("Bed: " + touched.getName());
            }
            if (touched.getTag() == "Bed" && touched.getName() == "UnderBed") {
                return true;
            }
        }
        return false;
    }
}

class OuchAchievement : AbstractAchievement
{
    public override string Name() { 
        return "OUCH!";
    }
    public override string Description() { 
        return "Attacked by cupboard.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getTag() == "Cupboard") {
                return true;
            }
        }
        return false;
    }
}
