using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoSingleton<PlaySound> {

    public AudioSource audio_bg;
    public AudioSource audio_step;
    public AudioSource audio_effect;
    public string ResourcesDir = "";
    protected override void Awake()
    {
        base.Awake();
        audio_bg = gameObject.AddComponent<AudioSource>();
        audio_bg.playOnAwake = false;
        audio_bg.loop = true;

        audio_step = gameObject.AddComponent<AudioSource>();
        audio_step.playOnAwake = false;
        audio_step.loop = true;

        audio_effect = gameObject.AddComponent<AudioSource>();
        audio_effect.playOnAwake = false;
    }

    public void PlayBgAudio(string audioName)
    {
        audio_bg.Play();
        string currentAudio = "";
        if (audio_bg.clip != null)
        {
            currentAudio = audio_bg.clip.name;
        }
        if (currentAudio != audioName)
        {
            string path = ResourcesDir + "/" + audioName;
            AudioClip clip = Resources.Load<AudioClip>(path);
            if (clip != null)
            {
                audio_bg.clip = clip;
                audio_bg.volume = 0.2f;
                audio_bg.Play();
            }
        }
    }

    public void StartStepAudio()
    {
        string path = ResourcesDir + "/" + Const.Se_UI_Run;
        AudioClip clip = Resources.Load<AudioClip>(path);
        if (clip != null)
        {
            audio_step.clip = clip;
            audio_step.volume = 0.37f;
            audio_step.pitch = 1.3f;
            audio_step.Play();
        }
    }

    public void StepAudioSpeedUp()
    {
        audio_step.pitch = 1.6f;
    }

    public void StepAudioSpeedDown()
    {
        audio_step.pitch = 1.3f;
    }

    public void PlayStepAudio()
    {
        audio_step.Play();
    }

    public void PauseBgAudio()
    {
        audio_bg.Pause();
    }

    public void PauseStepAudio()
    {
        audio_step.Pause();
    }

    public void PlayEffectAudio(string audioName)
    {
        string path = ResourcesDir + "/" + audioName;
        AudioClip clip = Resources.Load<AudioClip>(path);

        audio_effect.PlayOneShot(clip);
    }
}
