using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectsScript1 : MonoBehaviour
{
    public List<AudioClip> Sounds;
    public AudioSource adsrc;
    // Start is called before the first frame update
    public void makeSound() {

        adsrc.clip = Sounds[Random.Range(0, Sounds.Count - 1)];
        adsrc.Play();
    } 

}
