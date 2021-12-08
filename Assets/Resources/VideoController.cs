using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Video;
# if PLATFORM_IOS
using UnityEngine.iOS;
# endif

public class VideoController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer = null;

    [SerializeField]
    private GameObject canvus = null;

    [DllImport("__Internal")]
    private static extern void HTMLButtonPlugin();

    void Start()
    {
        StartCoroutine(SetPath());
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

    IEnumerator SetPath()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "content.mp4");
        yield return null;
    }

    public void Play()
    {
        videoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetDirectAudioMute(0, false);
        videoPlayer.SetDirectAudioVolume(0, 1);

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
