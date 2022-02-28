using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BGMSelector : MonoBehaviour
{
    public AudioClip[] BGM_Array;
    public AudioSource BGM_Player;
    public TextMeshProUGUI songTitleText;
    // Start is called before the first frame update
    void Start()
    {
        int songindex = Random.Range(0, BGM_Array.Length);
        BGM_Player.clip = BGM_Array[songindex];
        songTitleText.SetText(BGM_Array[songindex].ToString());
        BGM_Player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
