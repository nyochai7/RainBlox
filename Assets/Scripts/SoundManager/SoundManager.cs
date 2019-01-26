using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;
    public static SoundManager Instance{
        get{
            if(_instance == null){
                _instance = GameObject.FindObjectOfType<SoundManager>();
            }
            return _instance;
        }
        set{
            _instance = value;
        }
    }

    [SerializeField] private List<AudioSource> _audioSourceList;

    private void Awake() {
        foreach(Transform tr in transform){
            _audioSourceList.Add(tr.gameObject.GetComponent<AudioSource>());
        }
    }

    public AudioSource Play(string name){
        AudioSource ac = GetSoundByName(name);
        if(ac != null){
        ac.Play();
        return ac;
        }
        return null;
    }

    private AudioSource GetSoundByName(string name)
    {
        foreach (AudioSource ac in _audioSourceList)
        {
            if(ac.name.Contains(name)){
                return ac;
            }
        }
        return null;
    }
}
