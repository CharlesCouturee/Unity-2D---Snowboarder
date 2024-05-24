using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    new AudioSource audio;
    bool hasCrashed = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && audio && crashSFX && !hasCrashed) 
        {
            hasCrashed = true;
            GetComponent<PlayerController>().DisableControls();
            PlayCrashEffect();
            audio.PlayOneShot(crashSFX);
            Invoke("ReloadScene", crashDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    void PlayCrashEffect()
    {
        if (crashEffect)
        {
            crashEffect.Play();
        }
    }
}
