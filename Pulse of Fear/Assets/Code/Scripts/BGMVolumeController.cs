using UnityEngine;
using UnityEngine.Audio;

public class BGMVolumeController : MonoBehaviour
{
    public AudioMixer audioMixer; // Assign your Audio Mixer in the Inspector
    public float maxBGMVolume = 1.0f; // Maximum BGM volume
    public float minBGMVolume = 0.2f; // Minimum BGM volume when near an audio source zone
    public float audioSourceZoneRadius = 5.0f; // Adjust the radius as needed
    public Transform camera;

    void Update()
    {
        float bgmVolume = IsNearAudioSourceZone() ? minBGMVolume : maxBGMVolume;
        audioMixer.SetFloat("Volume", Mathf.Log10(bgmVolume) * 20); // Convert volume to logarithmic scale
    }

    bool IsNearAudioSourceZone()
    {
        // Check if the listener (e.g., player) is near any audio source zone

        
        Transform listener = camera.transform;

        // Iterate through all audio source zones and check their distance from the listener
        GameObject[] audioSourceZones = GameObject.FindGameObjectsWithTag("audio");

        foreach (GameObject audioSourceZone in audioSourceZones)
        {
            float distance = Vector3.Distance(listener.position, audioSourceZone.transform.position);

            if (distance < audioSourceZoneRadius)
            {
                return true; // Player is near an audio source zone
            }
        }

        return false; // Player is not near any audio source zone
    }
}
