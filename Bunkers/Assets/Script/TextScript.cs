using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour
{
    private Text text;
    private string[] finalText;
    private int placeInText;
    private int actualText;
    private float time;
    private float timeLastLetter;
    private int TimeTouch;
    public GameObject skip;
    public GameObject play;

    // Start is called before the first frame update
    void Start()
    {
        actualText = 0;
        TimeTouch = 0;
        placeInText = 0;
        finalText = new string[] {"Few years ago, a big apocalypse struck the world. You are one of the survivors. Those ones who didn't survive turned into Zombies. Their hobbies are to chase, kill and eat fresh humans meat. You're safe in a bunker since a lot of time, but unfortunally, the ressources started to be rare...",
            "Hopely, this morning you received a call from another bunker. Great no ? it means that there is other humans. It's YOUR opportunity to survive by finding food, and clean water. This bunker is really far from yours. You will have a lot of Zombies to kill to reach this bunker. But don't worry you have your beloved gun with you.",
            "If you're starting to miss some munitions you'll find several bunkers and houses in your way. The problem is that they're almost all loot and unsafe. Don't be discouraged you will maybe find munitions, or other stuffs, you have to open your eyes carfully ! To help you in your adventure you'll find a lot of weapons and munitions in the basement of each bunkers, but be carrefull, you'll maybe don't survive by trying to get them...",
            "We are hoping for you that you will reach the last bunker alive.\nGOOD LUCK !" };
        text = GetComponent<Text>();        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time - timeLastLetter > 0.04 && actualText < finalText.Length && placeInText < finalText[actualText].Length)
        {
            timeLastLetter = time;
            text.text += finalText[actualText][placeInText];
            ++placeInText;
        }
        if (actualText < finalText.Length && placeInText == finalText[actualText].Length && actualText == finalText.Length - 1)
        {
            skip.SetActive(false);
            play.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (actualText != 0 && actualText != finalText.Length)
            {
                if (actualText != finalText.Length)
                {
                    skip.SetActive(true);
                    play.SetActive(false);
                }
                --actualText;
                text.text = "";
                placeInText = finalText[actualText].Length;
                text.text = finalText[actualText];
                TimeTouch = 1;
            }
        }
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ++TimeTouch;
            if (actualText < finalText.Length && TimeTouch == 1)
            {
                placeInText = finalText[actualText].Length;
                text.text = finalText[actualText];
            }
            else if (actualText < finalText.Length && placeInText == finalText[actualText].Length)
            {
                ++actualText;
                text.text = "";
                placeInText = 0;
                TimeTouch = 0;
            }
            if (actualText == finalText.Length)
            {
                ++actualText;
                SceneManager.LoadScene("Map", LoadSceneMode.Single);
            }
        }
    }
}
