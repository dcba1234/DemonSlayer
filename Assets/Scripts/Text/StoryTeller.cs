using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class StoryTeller : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private float time = 0f;
    private TextMeshProUGUI currentText;
    public float delayTime = 5;
    public string[] texts; //About 1,000 years ago, In the land of OwtLand, people were living a peaceful and happy life.
    private int pos = 1;
    public GameObject Fade;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentText = GetComponent<TextMeshProUGUI>();
        currentText.text = texts[0];
    }
    void Start()
    {
        animator.SetTrigger("Appear");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (pos == texts.Length) {
            if (time >= texts[pos - 1].Length / 15)
            {
                Fade.GetComponent<FadeOut>().toFadeOut();
                return;
            }
                

       
        } 
        delayTime = texts[pos - 1].Length / 15;
        if (time >= delayTime)
        {
            currentText.text = @texts[pos];
            animator.Play("StoryText",-1,0f);
            pos++;
            time = 0;
        }
      
    }

}
