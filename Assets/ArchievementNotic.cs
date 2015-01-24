using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArchievementNotic : MonoBehaviour {


    public RectTransform notiBG;
    public Vector2 startPos;
    public Vector2 hidePos;
    public float translateSpeed = 0.1f;
    public float delay = 4f;

    public Text achievementMsg;
    public Text descriptionMsg;

    float timer = 0;
	
    void Start()
    {
        archievementUnlock("\"YEAH!\"", "You done it!");
        Debug.Log("eiei: "+Screen.width+" "+Screen.height);
    }

	// Update is called once per frame
	void Update () {
       timer += Time.deltaTime;
       if(timer >= delay)
        {
            Vector3 lerpTemp = Vector3.Lerp(notiBG.position, hidePos, translateSpeed);
            notiBG.position = new Vector2(lerpTemp.x, lerpTemp.y);
       }
	}

    public void archievementUnlock(string achievement, string description)
    {
        startPos = new Vector2 (Screen.width / 2, 380);
        hidePos = new Vector2 (Screen.width / 2, 800);
        achievementMsg.text = achievement;
        descriptionMsg.text = description;
        notiBG.position = startPos;
        timer = 0;
        Debug.Log("k");
    }
}
