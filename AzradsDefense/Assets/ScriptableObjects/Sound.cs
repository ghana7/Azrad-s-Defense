using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;

[CreateAssetMenu(menuName = "Custom Assets/Sound")]
public class Sound : ScriptableObject
{
    public string _name;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume;
    [Range(0, 2)]
    public float pitch;
    [Range(0, 1)]
    public float volumeVariance;
    [Range(0, 1)]
    public float pitchVariance;
    public bool looping;

    private void Awake()
    {
        if(Selection.activeObject != null)
        {
            if (Selection.activeObject.GetType() == typeof(AudioClip))
            {
                audioClip = (AudioClip)Selection.activeObject;
                _name = Selection.activeObject.name;
            }
        }
    }
    void Reset()
    {
        volume = 1;
        pitch = 1;
        volumeVariance = 0.1f;
        pitchVariance = 0.1f;
        looping = false;
    }
}
