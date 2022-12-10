using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] BossBehaviour boss;

    [Header("Компонент источника звука главной камеры")]
    [SerializeField] AudioSource cameraAudio;

    [Header("Снепшот при смене музыки")]
    [SerializeField] AudioMixerSnapshot changeMusicSnapshot;
    [Header("Стандартный снепшот")]
    [SerializeField] AudioMixerSnapshot standartSnapshot;

    [Space(10)]
    [Header("Длительность убавления громкости")]
    [SerializeField] float nextSnapshotTime;

    [Header("Длительность паузы при смене музыки")]
    [SerializeField] float nextSnapshotPause;

    [Header("Новый музыкальный клип")]
    [SerializeField] AudioClip newMusicClip;

    AudioClip standartMusicClip;

    private void Awake()
    {
        standartMusicClip = cameraAudio.clip;
        boss.healthHandler.OnDeath.AddListener(die => ChangeMusicClip(null));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInput>())
        {
            boss.enabled = true;

            boss.playerTransform = collision.transform;
            boss.OnPlayerFind.Invoke(collision.transform);

            ChangeMusicClip(newMusicClip);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInput>())
        {
            boss.playerTransform = null;
            boss.OnPlayerFind.Invoke(null);

            ChangeMusicClip(standartMusicClip);
        }
    }

    void ChangeMusicClip(AudioClip selectAudioClip)
    {
        changeMusicSnapshot.TransitionTo(nextSnapshotTime);
        cameraAudio.clip = selectAudioClip;

        StartCoroutine(ChangeMusicTimer());
    }

    IEnumerator ChangeMusicTimer()
    {
        yield return new WaitForSeconds(nextSnapshotPause);
        standartSnapshot.TransitionTo(nextSnapshotTime);
        cameraAudio.Play();
    }
}