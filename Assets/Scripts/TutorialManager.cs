using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;
    private int popUpIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        popUpIndex = 0;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < popUps.Length; i++)
        {
            popUps[i].SetActive(i == popUpIndex);
        }

        /*switch (popUpIndex)
        {
            case 0:
                if (Input.GetKeyDown("space")) {
                    Debug.Log("Space clicked1");
                    popUpIndex++;
                }
                break;
            case 1:
                Debug.Log("Were in case 2");
                if (Input.GetKeyDown("space"))
                {
                    Debug.Log("Space clicked2");
                    popUpIndex++;
                }
                break;            
            case 2:
                if (Input.GetKeyDown("space"))
                {
                    Debug.Log("Space clicked3");
                    popUpIndex++;
                    Time.timeScale = 1f;
                }
                break;
        }*/
    }


    public void next()
    {
        popUpIndex++;
        if(popUpIndex == 2)
        {
            Time.timeScale = 1f;
        }
    }

}
