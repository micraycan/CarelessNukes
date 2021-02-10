using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] explosions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayExplosionSound()
    {
        int rand = Random.Range(0, explosions.Length);

        explosions[rand].Play();
    }
}
