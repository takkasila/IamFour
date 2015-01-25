using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementController : MonoBehaviour {

    public ArchievementNotic achievementNoti;
    List<AbstractAchievement> achievements;
    bool[] isNotied = new bool[100];
    int achievementsCount;

	// Use this for initialization
	void Start () {
        //achievement = new List<AbstractAchievement>();
        for (int i=0; i<100 ; i++) isNotied[i] = false;
        achievementsCount = 0;
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
                new GlobalWarmingAchievement(),
                new DoorBangerAchievement(),
                new FuckHomeworkAchievement(),
                new NoMoreSchoolAchievement(),
                new StairFallRagdollAchievement(),
                new SorryMomAchievement(),
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
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Book") {
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
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Book" && touched.getAuthor() == "Head") {
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
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Floor") {
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
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Floor" && touched.getAuthor() == "Head") {
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
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "PlantPot") {
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
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Window") {
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
            if (touched.getAuthorTag() == "Player" && 
                touched.getTag() == "Bells" &&
                (touched.getAuthor() == "Left Hand" || touched.getAuthor() == "Right Hand")) {
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
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Bed" && touched.getName() == "UnderBed") {
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
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Cupboard") {
                return true;
            }
        }
        return false;
    }
}

class GlobalWarmingAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Global Warmer";
    }
    public override string Description() { 
        return "Throw plant out of the room.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getAuthorTag() == "Tracker" && touched.getTag() == "PlantPot") {
                return true;
            }
        }
        return false;
    }
}

class DoorBangerAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Door Banger";
    }
    public override string Description() { 
        return "Sent the door flying.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getAuthorTag() == "Tracker" && touched.getName() == "Door") {
                return true;
            }
        }
        return false;
    }
}

class FuckHomeworkAchievement : AbstractAchievement
{
    public override string Name() { 
        return "F*ck homework!";
    }
    public override string Description() { 
        return "Throw a book out.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getAuthorTag() == "Tracker" && touched.getTag() == "Book") {
                return true;
            }
        }
        return false;
    }
}


class NoMoreSchoolAchievement : AbstractAchievement
{
    public override string Name() { 
        return "No more school";
    }
    public override string Description() { 
        return "Throw all of the books out.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        List<string> books = new List<string>();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getAuthorTag() == "Tracker" && touched.getTag() == "Book") {
                string bookName = touched.getName();
                if (!books.Contains(bookName)) {
                    Debug.Log("BookName: "+bookName);
                    books.Add(bookName);
                }
            }
        }
        if (books.Count == 12) return true;
        return false;
    }
}

class StairFallRagdollAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Stairfall Ragdoll";
    }
    public override string Description() { 
        return "Fall down stair.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        List<string> books = new List<string>();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Floor" && touched.getName() == "Floor2") {
                return true;
            }
        }
        return false;
    }
}

class SorryMomAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Sorry, Mom";
    }
    public override string Description() { 
        return "Hit chandelier.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        List<string> books = new List<string>();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Chandelier") {
                return true;
            }
        }
        return false;
    }
}
/*
class SorryMomAchievement : AbstractAchievement
{
    public override string Name() { 
        return "Sorry, Mom";
    }
    public override string Description() { 
        return "Hit chandelier.";
    }
    public override bool IsEarned()
    {
        List<TouchLog> playerTouchLog = GameState.getTouchLogList();
        List<string> books = new List<string>();
        foreach (TouchLog touched in playerTouchLog) {
            if (touched.getAuthorTag() == "Player" && touched.getTag() == "Chandelier") {
                return true;
            }
        }
        return false;
    }
}*/