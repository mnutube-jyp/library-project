using System.Collections;
using UnityEngine;
using UnityEngine.Video;

#if UNITY_WEBGL && !UNITY_EDITOR
using AOT;
using System.Runtime.InteropServices;
#endif

public class ContentVideo : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport( "__Internal" )]
    private static extern bool CheckForWebGLIOS();
#else
    private static bool CheckForWebGLIOS()
    {
        return false;
    }
#endif

    [SerializeField]
    private VideoPlayer unityVideoPlayer = null;

    [SerializeField]
    private GameObject canvus = null;

    private AudioSource audioSource;

    public void Start()
    {
        PrepareUnityVideoPlayer();

    }

    private void Update()
    {
        StartCoroutine(CheckPopupOpen());
    }

    public void PrepareUnityVideoPlayer()
    {
        unityVideoPlayer = unityVideoPlayer == null ? Camera.main.gameObject.AddComponent<VideoPlayer>() : unityVideoPlayer;
        unityVideoPlayer.renderMode = VideoRenderMode.RenderTexture;

        audioSource = unityVideoPlayer.gameObject.AddComponent<AudioSource>();
        unityVideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        unityVideoPlayer.SetTargetAudioSource(0, audioSource);

        unityVideoPlayer.source = VideoSource.Url;

        unityVideoPlayer.isLooping = true;

        SetVideoUrl(System.IO.Path.Combine(Application.streamingAssetsPath, "content.mp4"));
    }

    public void OnClickButton()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        if (CheckForWebGLIOS() == true)
        {
            // Webgl on mobile IOS devices will not auto play because safari wants play to be called with user intent so from an HTML button 
            unityVideoPlayer.waitForFirstFrame = false;
            unityVideoPlayer.playOnAwake = false;

            // We have to use unityInstance.SendMessage to call play from an html button which requieres the name of the gameobject and the method. The method being Play
            // We use a list of video player names so we can call play on multiple players if we want 
            // Add all the names you want then we show the html button 
            IOSWebPlaybackHelper.Instance.AddToVideoList(gameObject.name);

            // The html button should be a grey overlay when you press it the it calls play with unityInstance.SendMessage satisfying the requirment of user intent 
            IOSWebPlaybackHelper.Instance.ShowHtmlButton();
        }
            
        // WEBGL Requires you to use Direct audio type
        unityVideoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;
#else
        

        unityVideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        unityVideoPlayer.SetTargetAudioSource(0, audioSource);
#endif
        UnMute();
    }

    public void SetVideoUrl(string url)
    {
        unityVideoPlayer.url = url;
    }

    public void Play()
    {
        unityVideoPlayer.Play();
    }

    public void ToggleAudio()
    {
        if (IsMuted() == true)
        {

            UnMute();
        }
        else
        {
            Mute();
        }

    }

    public bool IsMuted()
    {

#if !UNITY_EDITOR && UNITY_WEBGL
             
        // In webgl builds is muted can be determined with GetDirectAudioMute
        return unityVideoPlayer.GetDirectAudioMute(0);
#else
        return unityVideoPlayer.GetTargetAudioSource(0).mute;
#endif
    }

    public void Mute()
    {

#if !UNITY_EDITOR && UNITY_WEBGL

        // In webgl builds mute has to be set with direct audio mute
        unityVideoPlayer.SetDirectAudioMute(0, true);
#else
        unityVideoPlayer.GetTargetAudioSource(0).mute = true;
#endif

    }

    public void UnMute()
    {

#if !UNITY_EDITOR && UNITY_WEBGL

        // In webgl builds unmute has to be set with direct audio mute
        unityVideoPlayer.SetDirectAudioMute(0, false);
#else
        unityVideoPlayer.GetTargetAudioSource(0).mute = false;
#endif

    }

    public void SetVolume(float vol)
    {
        if (vol > 1)
        {
            vol = 1;
        }
        else if (vol < 0)
        {
            vol = 0;
        }

#if !UNITY_EDITOR && UNITY_WEBGL

        // In webgl build video audio will have to be managed through the direct audio 
        unityVideoPlayer.SetDirectAudioVolume(0, vol);
#else
        audioSource.volume = vol;
#endif

    }
    IEnumerator CheckPopupOpen()
    {
        if (canvus.transform.childCount < 1)
        {
            Mute();
        }

        yield return new WaitForSeconds(0.5f);
    }

} //END class