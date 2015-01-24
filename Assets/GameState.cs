using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TouchLog
{
    string name;
    string tag;
    public TouchLog(string name, string tag)
    {
        this.name = name;
        this.tag = tag;
    }

    public string getName()
    {
        return name;
    }
    public string getTag()
    {
        return tag;
    }
}

public class GameState : MonoBehaviour {

    static List<TouchLog> touchLogList = new List<TouchLog>();


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public List<TouchLog> getTouchLogList()
    {
        return touchLogList;
    }
    public TouchLog getLastestTouchLog()
    {
        if (touchLogList.Count <= 0)
            return null;
        return touchLogList[touchLogList.Count - 1];
    }


}
