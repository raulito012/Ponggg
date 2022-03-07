using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource asSounds;

    public AudioClip marcadorSound;
    public AudioClip ganarSound;

    public void PlayScoreSound()
    {
        asSounds.PlayOneShot(marcadorSound);
    }

    public void PlayWinSound()
    {
        asSounds.PlayOneShot(ganarSound);
    }
}
