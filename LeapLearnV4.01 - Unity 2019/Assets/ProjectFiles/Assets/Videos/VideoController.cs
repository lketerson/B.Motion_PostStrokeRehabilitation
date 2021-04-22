using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoBoxNBlocks;
    public VideoPlayer videoReactionTime;
    public RawImage playPauseBNB;
    public RawImage playPauseRT;

    // Start is called before the first frame update
    private void Awake()
    {
        videoReactionTime.Pause();
        videoBoxNBlocks.Pause();

    }
    
    public void PlayVideoBnB()
    {
        if (videoBoxNBlocks.isPaused)
        {
            videoBoxNBlocks.Play();
            playPauseBNB.enabled = false;
        }
        else
        {
            videoBoxNBlocks.Pause();
            playPauseBNB.enabled = true;
        }
        
    }

    public void PlayVideoRT()
    {
        if (videoReactionTime.isPaused)
        {
            videoReactionTime.Play();
            playPauseRT.enabled = false;
        }
        else
        {
            videoReactionTime.Pause();
            playPauseRT.enabled = true;
        }
    }
}
