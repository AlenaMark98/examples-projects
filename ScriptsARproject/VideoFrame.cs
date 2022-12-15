using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFrame : MonoBehaviour
{
    [SerializeField] private List<VideoClip> videoClipToPlace;

    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void ChangeVideo(int indexBT)
    {
        videoPlayer.playOnAwake = false;

        videoPlayer.clip = videoClipToPlace[indexBT];

        videoPlayer.isLooping = true;

        videoPlayer.loopPointReached += EndReached;

        videoPlayer.Play();

    }

    public void PlayVideo()
    {
        videoPlayer.Play();
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }

    public void StopVideo() 
    {
        videoPlayer.Stop();
    }

    void EndReached(VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }

}
