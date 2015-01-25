using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TouchLog
{
    string author;
    string authortag;
    string name;
    string tag;
    int frameStamp;

    public TouchLog(string author, string authortag, string name, string tag, int frameStamp)
    {
        this.author = author;
        this.authortag = authortag;
        this.name = name;
        this.tag = tag;
        this.frameStamp = frameStamp;
        //TimeStamp = Time.getFrameCount() <-Unity Time
    }

    public string getAuthor() {
        return author;
    }

    public string getAuthorTag() {
        return authortag;
    }

    public string getName() {
        return name;
    }
    
    public string getTag() {
        return tag;
    }

    public int getFrameStamp() {
        return frameStamp;
    }
}

public class GameState : MonoBehaviour {

    static List<TouchLog> touchLogList = new List<TouchLog>();

    public static List<TouchLog> getTouchLogList()
    {
        return touchLogList;
    }
    public static TouchLog getLastestTouchLog()
    {
        if (touchLogList.Count <= 0)
            return null;
        return touchLogList[touchLogList.Count - 1];
    }
    public static void submitTouchLog(TouchLog submitLog)
    {
        touchLogList.Add(submitLog);
    }


}
