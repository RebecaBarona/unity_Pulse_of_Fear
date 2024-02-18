using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoPlayerManager : MonoBehaviour
{
    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    private int currentClipIndex = 0;
    private float videoStartTime;
    public Button skipButton;
    public RawImage videoDisplay;
    private AsyncOperation sceneLoadingOperation;

    public FadeScreen fadeScreen;
    void Start()
    {
      
        videoPlayer = GetComponentInChildren<VideoPlayer>();

        // Set up the first video clip
        PlayVideoClip(videoClips[currentClipIndex]);

        // Add a listener to the skip button
        skipButton.onClick.AddListener(SkipVideo);
    }

    void PlayVideoClip(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Play();

        //videoStartTime = Time.time;
        StartCoroutine(WaitForVideo());
    }

    public void SkipVideo()
    {
        StopAllCoroutines();
        MoveToNextClip();
    }

  
   
    void Update()
    {
        // Check for spacebar input to skip
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipVideo();
        }

        RenderTexture renderTexture = videoPlayer.texture as RenderTexture;
        if (renderTexture != null)
        {
            videoDisplay.texture = renderTexture;
        }
    }

    void MoveToNextClip()
    {
        currentClipIndex++;
        if (currentClipIndex < videoClips.Length)
        {
            PlayVideoClip(videoClips[currentClipIndex]);
        }
        else
        {
            Debug.Log("No more videos to play.");
            fadeScreen.FadeIn();
            //SceneManager.LoadScene(2);
            // You can handle what to do when all videos are played
        }
    }

    IEnumerator WaitForVideo()
    {
        while (true)
        {
            videoStartTime += Time.deltaTime;
            if (videoStartTime >= 8f)
            {videoStartTime = 0;
                MoveToNextClip();
                break;
            }
            yield return null;
        }
    }
}
