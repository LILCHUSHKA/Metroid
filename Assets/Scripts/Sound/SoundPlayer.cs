using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    AudioSource audioPlayer;
    [SerializeField] AudioClip[] runClips;

    private void Awake() => audioPlayer = GetComponent<AudioSource>();
    public void PlaySound(AudioClip playSound) => audioPlayer.PlayOneShot(playSound);
    public void PlayRandomRunSound() => audioPlayer.PlayOneShot(runClips[Random.Range(0, runClips.Length)]);
}