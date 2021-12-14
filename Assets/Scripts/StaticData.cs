using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticData : MonoBehaviour
{

    public int Health = 0;
    public bool BigDick = false;
    
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        if(Input.GetKeyDown("0"))
        {
            Debug.Log("This bich still alive!!!!!: " + Health);
        }

        GetPressedNumber();
    }



    public void GetPressedNumber()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("Going to Main menu");
            SceneManager.LoadScene("Menu");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            Debug.Log("Going to intro cut scene");
            SceneManager.LoadScene("IntroCutScene");
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            Debug.Log("Going to Main Hub");
            SceneManager.LoadScene("MainHub");
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            Debug.Log("Going to Fight Arena");
            SceneManager.LoadScene("FightArena");
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            Debug.Log("Going to Item Shop");
            SceneManager.LoadScene("ItemShop");
        }
    }





    public int getHealth(){
        return Health;
    }

    public void setHealth(int newValue){
        Health += newValue;
        Debug.Log("Health was updated: " + Health);
    }
}
