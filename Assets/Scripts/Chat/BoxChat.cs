using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxChat : MonoBehaviour
{
    private TextMeshProUGUI text;
    public string[] texts;
    public float timePerChar;
    private string textToWrite;
    private int pos = 0;
    private float timer;
    private int characterIndex = 0;
    private bool isTalked = false;
    public GameObject knight;
    public GameObject boxChat;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
      
    }

    //// Update is called once per frame
    void Update()
    {
        textToWrite = @texts[pos];
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            if (characterIndex > textToWrite.Length - 1) return;
            timer += timePerChar;
            characterIndex++;
            text.SetText(textToWrite.Substring(0, characterIndex));
        }
    }

    public void nextConversation()
    {
        if(pos < texts.Length - 1 )
        {
            characterIndex = 0;
            pos++;
        }
        else
        {
            isTalked = true;
            knight.GetComponent<Knight>().activeRunInStory1();
            boxChat.SetActive(false);
        }
    }
}
