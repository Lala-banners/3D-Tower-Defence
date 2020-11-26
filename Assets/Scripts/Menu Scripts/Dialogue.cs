using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Dialogue is for the tutorial to set up the story of the game.
    public TMP_Text textDisplay;
    public string[] sentences;
    private int textIndex;
    public float typingSpeed;
    public GameObject nextButton;
    public GameObject mechanics;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if(textDisplay.text == sentences[textIndex])
        {
            nextButton.SetActive(true);
        }
    }

    //Storing the sentences to loop through the index and making the text appear in order and with speed
    IEnumerator Type()
    {
        foreach (char letter in sentences[textIndex].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //Function for setting the next sentence in the index and starting the coroutine 
    public void NextSentence()
    {
        nextButton.SetActive(false);
        //If the text index is less than the length of the sentence then go to the next sentence in the index
        if (textIndex < sentences.Length -1)
        {
            textIndex++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            nextButton.SetActive(false);
        }
    }

}
