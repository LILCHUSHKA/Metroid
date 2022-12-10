using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] BossBehaviour boss;

    [Header("��������� ��������� ����� ������� ������")]
    [SerializeField] AudioSource cameraAudio;

    [Header("������� ��� ����� ������")]
    [SerializeField] AudioMixerSnapshot changeMusicSnapshot;
    [Header("����������� �������")]
    [SerializeField] AudioMixerSnapshot standartSnapshot;

    [Space(10)]
    [Header("������������ ��������� ���������")]
    [SerializeField] float nextSnapshotTime;

    [Header("������������ ����� ��� ����� ������")]
    [SerializeField] float nextSnapshotPause;

    [Header("����� ����������� ����")]
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