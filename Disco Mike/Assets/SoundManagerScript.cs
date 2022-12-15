using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip ShootSound, JumpSound, LandSound, HitSound, SweepSound,TakeDamage, Run;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        ShootSound = Resources.Load<AudioClip>("Shoot11");
        JumpSound = Resources.Load<AudioClip>("Jump");
        LandSound = Resources.Load<AudioClip>("Land");
        HitSound = Resources.Load<AudioClip>("Hit");
        SweepSound = Resources.Load<AudioClip>("Sweep");
        //Paavon
        TakeDamage = Resources.Load<AudioClip>("PlayerTakeDamage");
        Run = Resources.Load<AudioClip>("Run");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Jump":
                audioSrc.PlayOneShot (JumpSound);
                break;

            case "Shoot":
                audioSrc.PlayOneShot (ShootSound);
                break;

            case "Land":
                audioSrc.PlayOneShot(LandSound);
                break;            
            case "Hit":
                audioSrc.PlayOneShot(HitSound);
                break;
            case "Sweep":
                audioSrc.PlayOneShot(SweepSound);
                break;
            case "TakeDamage":
                audioSrc.PlayOneShot(TakeDamage);
                break;
            case "Run":
                audioSrc.PlayOneShot(Run);
                break;
        
        
        }
    }
}






