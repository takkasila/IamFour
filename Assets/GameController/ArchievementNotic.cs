using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ArchievementNotic : MonoBehaviour {


    public RectTransform notiBG;
    public Vector2 startPos;
    public Vector2 hidePos;
    public float translateSpeed = 0.1f;
    public float delay = 4f;

    public Text achievementMsg;
    public Text descriptionMsg;
    public GameObject starParticle;

    List<ArchievementData> popList = new List<ArchievementData>();

    float timer = 0;
	
    void Start()
    {
        archievementUnlock("What do we do now?","Greetings to you!");
    }

	// Update is called once per frame
	void Update () {


        if(popList.Count > 0)
        {
            if(popList[0].isStart)
            {
                //Add some shitty particles

                startPos = new Vector2 (Screen.width / 2, Screen.height - notiBG.rect.height/2 - 10);
                hidePos = new Vector2 (Screen.width / 2, Screen.height + notiBG.rect.height + 10);
                achievementMsg.text = popList[0].achievement;
                descriptionMsg.text = popList[0].description;
                notiBG.position = startPos;
                timer = 0;
                popList[0].isStart = false;

                Vector3 temp = Camera.main.ScreenToWorldPoint(startPos);
                temp = new Vector3(temp.x, temp.y, -10f);
                Instantiate(starParticle, temp, Quaternion.identity);

            }
            else
            {

                timer += Time.deltaTime;
                if(timer >= delay)
                {
                    Vector3 lerpTemp = Vector3.Lerp(notiBG.position, hidePos, translateSpeed);
                    notiBG.position = new Vector2(lerpTemp.x, lerpTemp.y);

                    if(Vector2.Distance(notiBG.position, hidePos) <= 1)
                    {
                        notiBG.position = hidePos;
                        popList.RemoveAt(0);
                    }
               }

            }
        }

        //delay
       
	}

    public void archievementUnlock(string achievement, string description)
    {
        popList.Add(new ArchievementData(achievement, description));

        /*
        */
    }
}

public class ArchievementData
{
    public bool isStart = true;
    public string achievement;
    public string description;

    public ArchievementData(string achievement, string description)
    {
        this.achievement = achievement;
        this.description = description;

    }
}