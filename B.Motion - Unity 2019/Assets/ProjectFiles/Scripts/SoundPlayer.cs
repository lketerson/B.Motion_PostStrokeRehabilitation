using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    public AudioSource buttonSound;
    // Start is called before the first frame update
  
    public void PlayButtonSound()
    {
        buttonSound.Play();
    }
}
