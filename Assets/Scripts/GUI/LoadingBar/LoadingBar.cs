using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image loadingBar;
    public GameObject loadingScene;
    public GameObject text;
    private void Awake()
    {
        
        loadingBar = GetComponent<Image>();
        loadingBar.fillAmount = 0.0f;
        
    }
    private void Start()
    {
        this.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText("Loading 0%");
    }
    public void loadLevel(string sceneNameToLoad)
    {
        loadingScene.SetActive(true);
        StartCoroutine(LoadSynchronously(sceneNameToLoad));
    }
    async void loadScene(string sceneNameToLoad)
    {
        _ = StartCoroutine(LoadSynchronously(sceneNameToLoad));
    }
    IEnumerator LoadSynchronously(string sceneNameToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNameToLoad);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {  
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            this.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText("Loading "+progress * 100+"%");
            if (progress > 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            loadingBar.fillAmount = progress;
            yield return null;
        }
        

    }
}
