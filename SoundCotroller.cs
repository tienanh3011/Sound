
using System.Collections.Generic;
using UnityEngine;


public class SoundController : MonoBehaviour
{
    [SerializeField] private List<Sounds> sounds;
    [SerializeField] private List<Sounds> musics;

    private void Awake()
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            sounds[i].audio = gameObject.AddComponent<AudioSource>();
            sounds[i].audio.clip = sounds[i].clip;
            sounds[i].audio.priority = 1;
            sounds[i].audio.playOnAwake = false;
            sounds[i].audio.volume = sounds[i].volume;
        }

        for (int i = 0; i < musics.Count; i++)
        {
            musics[i].audio = gameObject.AddComponent<AudioSource>();
            musics[i].audio.clip = musics[i].clip;
            musics[i].audio.playOnAwake = false;
            musics[i].audio.volume = musics[i].volume;
        }
    }

    public void PlaySound(SoundName name)
    {
        Sounds sound = sounds.Find(x => x.name == name);
        sound?.audio.Play();
    }

    public void PlayMusic(SoundName name, bool loop = false)
    {
        if (!IsMusic())
        {
            return;
        }

        Sounds music = musics.Find(x => x.name == name);
        if (music != null)
        {
            
            music.audio.priority = 128;
            music.audio.loop = loop;
            music.audio.Play();
        }
    }

    public void StopSound(SoundName name)
    {
        Sounds sound = sounds.Find(x => x.name == name);
        sound?.audio.Stop();
    }

    public void StopMusic(SoundName name)
    {
        Sounds music = musics.Find(x => x.name == name);
        music?.audio.Stop();
    }

    public void SoundUpdate(bool mute)
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            sounds[i].audio.mute = mute;
        }
    }

    public void MusicUpdate(bool mute)
    {
        for (int i = 0; i < musics.Count; i++)
        {
            musics[i].audio.mute = mute;
        }
    }

    public bool IsSound()
    {
        return true;
    }

    public bool IsMusic()
    {
        return true;
    }


}

[System.Serializable]
public class Sounds
{
    public SoundName name;
    [Range(0, 1)]
    public float volume = 1;
    public AudioClip clip;
    [HideInInspector] public AudioSource audio;
}

public enum SoundName
{
    walk,
    jump,
    hit,
    die,
    eatItem

}