using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private bool advancedDebugLogs;
    public static SoundManager instance;
    [Tooltip("The file path to search for sounds in - leave empty to search through all assets in Resources.\n\n" +
        "It is far more efficient to keep all Sound ScriptableObjects in one folder and give its path here.\n\n" +
        "Keep in mind that this path is relative to the Resources folder in your project, so for example, if " +
        "soundPath is set to 'Sounds' then it will search in Resources/Sounds. If you don't have a Resources folder, make one under Assets.")]
    [SerializeField]
    private string soundPath;
    private int numStartingSources = 3;
    private Dictionary<string, Sound> soundDict;

    private float globalVolume = 0.5f;

    private List<iAudioSource> audioSourcePool;
    [System.Serializable]
    private class iAudioSource
    {
        public AudioSource audioSource;
        public int id;

        public iAudioSource(AudioSource audioSource, int id)
        {
            this.audioSource = audioSource;
            this.id = id;
        }
    }
    private void Awake()
    {
        Sound[] sounds = Resources.LoadAll<Sound>(soundPath);
        audioSourcePool = new List<iAudioSource>();
        soundDict = new Dictionary<string, Sound>();
        foreach (Sound s in sounds)
        {
            soundDict[s._name] = s;
        }
        Debug.Log("Successfully loaded " + soundDict.Count + " sounds");
        if(advancedDebugLogs)
        {
            foreach(Sound s in sounds)
            {
                Debug.Log(" - added sound \"" + s._name + "\"");
            }
        }
        for (int i = 0; i < numStartingSources; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            audioSourcePool.Add(new iAudioSource(source, -1));
        }

        instance = this;
    }

    /// <summary>
    /// Plays a sound given its name
    /// </summary>
    /// <param name="name">The name of the sound you want to play, as defined in its Sound ScriptableObject</param>
    /// <returns>A unique integer id. This can be used to stop the sound early, by calling StopSound(id)</returns>
    public int PlaySound(string name)
    {
        if (soundDict.ContainsKey(name))
        {
            Sound sound = soundDict[name];

            bool foundSource = false;
            for (int i = 0; i < audioSourcePool.Count; i++)
            {
                AudioSource source = audioSourcePool[i].audioSource;
                if (!source.isPlaying)
                {
                    foundSource = true;
                    source.clip = sound.audioClip;
                    source.volume = sound.volume * (1f + Random.Range(-sound.volumeVariance / 2f, sound.volumeVariance / 2f)) * globalVolume;
                    source.pitch = sound.pitch * (1f + Random.Range(-sound.pitchVariance / 2f, sound.pitchVariance / 2f));
                    source.Play();
                    audioSourcePool[i].id = Random.Range(0, int.MaxValue);
                    //Debug.Log("playing sound on audiosource " + i + ", id " + audioSourcePool[i].id);
                    return audioSourcePool[i].id;
                }
            }
            if (!foundSource)
            {
                //create new audio source
                AudioSource source = gameObject.AddComponent<AudioSource>();

                source.clip = sound.audioClip;
                source.volume = sound.volume * (1f + Random.Range(-sound.volumeVariance / 2f, sound.volumeVariance / 2f)) * globalVolume;
                source.pitch = sound.pitch * (1f + Random.Range(-sound.pitchVariance / 2f, sound.pitchVariance / 2f));
                source.Play();

                int id = Random.Range(0, int.MaxValue);
                audioSourcePool.Add(new iAudioSource(source, id));
                return id;
            }
            //will never hit here but needs a return to compile
            return -2;
        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// Stops one specific instance of a sound, given its id
    /// </summary>
    /// <param name="id">The id of the sound to be stopped</param>
    public void StopSound(int id)
    {
        int index = 0;
        bool found = false;
        //Debug.Log("stopping " + id);
        for (int i = 0; i < audioSourcePool.Count; i++)
        {
            if (audioSourcePool[i].id == id)
            {
                index = i;
                found = true;
            }
        }
        if (found)
        {
            //Debug.Log("found");
            audioSourcePool[index].audioSource.Stop();
            audioSourcePool[index].id = -1;
        }
    }

    /// <summary>
    /// Plays one of multiple sounds, chosen at random, with each sound having an equal chance
    /// </summary>
    /// <param name="list">Any number of names of sounds</param>
    /// <returns>A unique integer id. This can be used to stop the sound early, by calling StopSound(id)</returns>
    public int PlaySound(params string[] list)
    {
        return PlaySound(list[Random.Range(0, list.Length)]);
    }

    private void ClearOutSources()
    {
        for (int i = 0; i < audioSourcePool.Count; i++)
        {
            if (!audioSourcePool[i].audioSource.isPlaying && audioSourcePool.Count > numStartingSources)
            {
                audioSourcePool.RemoveAt(i);
                i--;
            }
        }
    }

    /// <summary>
    /// Sets the global volume for all sounds.
    /// </summary>
    /// <param name="amount">The new volume, a float between 0 and 1</param>
    public void SetGlobalVolume(float amount)
    {
        float oldGlobalVolume = globalVolume;
        globalVolume = amount;
        foreach (iAudioSource source in audioSourcePool)
        {
            source.audioSource.volume *= (globalVolume / oldGlobalVolume);
        }
    }
}
