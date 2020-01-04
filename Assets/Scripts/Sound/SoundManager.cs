using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioClip AttSound,WalkSound,AttHit,GetHit;
    static AudioSource audioSource;
    void Start()
    {
        AttSound = Resources.Load<AudioClip>("Attack");
        WalkSound = Resources.Load<AudioClip>("Walk");
        AttHit = Resources.Load<AudioClip>("AttHit");
        GetHit = Resources.Load<AudioClip>("GetHit");
        
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch(clip){
            case "Attack":
                audioSource.PlayOneShot(AttSound);
                break;
            case "Walk":
                audioSource.PlayOneShot(WalkSound);
                break;
            case "AttHit":
                audioSource.PlayOneShot(AttHit);
                break;
            case "GetHit":
                audioSource.PlayOneShot(GetHit);
                break;
        }
    }
}
