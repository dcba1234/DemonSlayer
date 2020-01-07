using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportGate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rolateSpeed = 10f;
    public string nextSceneName;
    public bool hasLoading = false;
    public GameObject loadingLv;
    public GameObject loadingScreen;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (hasLoading)
            {
                loadingScreen.SetActive(true);
                loadingLv.GetComponent<LoadingBar>().loadLevel(nextSceneName);
                return;
            }
            SceneManager.LoadScene(nextSceneName);
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * -rolateSpeed);    
    }
}
