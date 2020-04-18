using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip sell;
    public static AudioClip build;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        build = Resources.Load<AudioClip>("build");
        sell= Resources.Load<AudioClip>("sell");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "build":
                audioSrc.PlayOneShot(build);
                break;
            case "sell":
                audioSrc.PlayOneShot(sell);
                break;
        }
    }
}
