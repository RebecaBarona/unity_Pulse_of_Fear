using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private int currentClipIndex = 0;
    public Button skipButton;
    public RawImage videoDisplay;

    void Start()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();

        // Set up the first video clip
        PlayVideoClip(videoClips[currentClipIndex]);

        // Add a listener to the skip button
        skipButton.onClick.AddListener(SkipVideo);
    }

    void PlayVideoClip(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Play();
        audioSource.clip = null; // Clear previous audio clip
        if (clip.audioTrackCount > 0)
        {
            videoPlayer.EnableAudioTrack(0, true);
         //   audioSource.clip = videoPlayer.GetAudioSample().audioClip;
        }
        audioSource.Play();
        StartCoroutine(WaitForVideoToEnd());
    }

    void SkipVideo()
    {
        MoveToNextClip();
    }

    void Update()
    {
        // Check for spacebar input to skip
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToNextClip();
        }

        RenderTexture renderTexture = videoPlayer.texture as RenderTexture;
        if (renderTexture != null)
        {
            videoDisplay.texture = renderTexture;
        }
    }

    void MoveToNextClip()
    {
        StopAllCoroutines();
        currentClipIndex++;
        if (currentClipIndex < videoClips.Length)
        {
            PlayVideoClip(videoClips[currentClipIndex]);
        }
        else
        {
            Debug.Log("No more videos to play.");
            // You can handle what to do when all videos are played
        }
    }

    IEnumerator WaitForVideoToEnd()
    {
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        if (currentClipIndex < videoClips.Length - 1)
        {
            currentClipIndex++;
            PlayVideoClip(videoClips[currentClipIndex]);
        }
        else
        {
            Debug.Log("No more videos to play.");
            // You can handle what to do when all videos are played
        }
    }
}
