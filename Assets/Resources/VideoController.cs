using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer = null;

    [SerializeField]
    private GameObject canvus = null;

    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "content.mp4");
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && videoPlayer.isPlaying == false)
        {
            Play();
        }

        if (canvus.transform.childCount < 1)
        {
            SetVolumeMin();
        }
    }

    void Play()
    {
        videoPlayer.Play();
        videoPlayer.isLooping = true;
    }

    public void SetVolumeMax()
    {
        videoPlayer.SetDirectAudioMute(0, false);
        videoPlayer.SetDirectAudioVolume(0, 1);
    }

    public void SetVolumeMin()
    {
        videoPlayer.SetDirectAudioMute(0, true);
        videoPlayer.SetDirectAudioVolume(0, 0);
    }
}
