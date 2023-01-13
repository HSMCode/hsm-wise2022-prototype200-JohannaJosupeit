using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTime : MonoBehaviour

{
    public Text counterText;
    public float seconds, minutes;
    //public bool isPlaying = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;

    }

    // Update is called once per frame
    void Update()

    {
         if (Input.GetKeyDown(KeyCode.Space))
     {
         
        minutes = (int)(Time.time/60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = "Highscore: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        
     }
       
    }

    // muss herausfinden wie geanu ich schreiben muss dass einmal spaxe up and down = start timer ist 
    
}
