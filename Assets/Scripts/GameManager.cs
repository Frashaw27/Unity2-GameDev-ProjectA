using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     //Sets it as a manager
    public static GameManager Instance { get; private set; }
    public bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject[] pauseableObjects;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        // Persist this GameObject across all scenes
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void Pause(){
        isPaused = true;
        foreach (var i in pauseableObjects){
            Rigidbody2D rb = i.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    public void Unpause(){
        isPaused = false;
        foreach (var i in pauseableObjects){
            Rigidbody2D rb = i.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
