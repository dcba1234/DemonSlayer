using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loadingLv;
    public string loaddingSceneName;
    private void Awake()
    {
        
    }

    // Update is called once per frame
    public void startClick()
    {
        if (GameSystem.isfistTime())
        {
            loadingLv.SetActive(true);
            loadingLv.GetComponent<LoadingBar>().loadLevel(loaddingSceneName); 
        }
            //SceneManager.LoadScene("StoryBegin1");
           // loading.loadLevel("StoryBegin1");
        else
        {
            SceneManager.LoadScene("TestScene");
        }

    }
}
