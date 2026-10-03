using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    public int buttonLogic;
    public int sceneTransfer;
    public Button button;
    public GameObject rootGroup;
    public GameObject differentGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
		button.GetComponent<Button>().onClick.AddListener(startOnClick);
    }

    //Goes to the first real level, resets things back to the basics incase of using the reset button
    public void startOnClick(){
        //Changing the current scene
        if (buttonLogic == 1){
            SceneManager.LoadScene(sceneTransfer);
            if (rootGroup != null) rootGroup.SetActive(false);
        //Showing different UI on Titlescreen
        } else if (buttonLogic == 2){
            rootGroup.SetActive(false);
            differentGroup.SetActive(true);
        } else if (buttonLogic == 3){
            GameManager.Instance.Unpause();
            rootGroup.SetActive(false);
        //Exits the game
        } else if (buttonLogic == -1){
            //Debug.Log("ggg");
            Application.Quit();//
        }
	}
}
