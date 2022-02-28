using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class changeUI : MonoBehaviour
{
    public TextMeshProUGUI GameNameText;
    public TextMeshProUGUI GameDescriptionText;
    public TextMeshProUGUI GameReleaseDateText;
    public TextMeshProUGUI preciseReleaseDateText;
    public VideoPlayer backgroundVideo;
    public AudioSource TickerNoise;

    public string[] GameNames;
    public string[] GameDescriptions;
    public string[] preciseDates;
    public int[] releaseDates;
    
    public VideoClip[] backgroundVideos;

    public float tickSleep = 0.05f;
    
    int oldReleaseDate;
    
    private void Start()
    {
        oldReleaseDate = int.Parse(GameReleaseDateText.text);
    }
    // Start is called before the first frame update
    IEnumerator releasedateTickerUp(int oldReleaseDate, int gameInfoIndex)
    {
        for (int i = oldReleaseDate; i <= releaseDates[gameInfoIndex]; i++)
        {
            GameReleaseDateText.SetText(i.ToString());
            TickerNoise.Play();
            yield return new WaitForSecondsRealtime(tickSleep);
        }
        
    }
    IEnumerator releasedateTickerDown(int oldReleaseDate, int gameInfoIndex)
    {
        for (int i = oldReleaseDate; i >= releaseDates[gameInfoIndex]; i--)
        {
            GameReleaseDateText.SetText(i.ToString());
            TickerNoise.Play();
            yield return new WaitForSecondsRealtime(tickSleep);
        }
    }
    public void UpdateText(int gameInfoIndex)
    {
        GameNameText.SetText(GameNames[gameInfoIndex]);
        GameDescriptionText.SetText(GameDescriptions[gameInfoIndex]);
        preciseReleaseDateText.SetText(preciseDates[gameInfoIndex]);

        if(oldReleaseDate < releaseDates[gameInfoIndex])
        {
            StopAllCoroutines();
            StartCoroutine(releasedateTickerUp(oldReleaseDate, gameInfoIndex));
            
        }else
        {
            StopAllCoroutines();
            StartCoroutine(releasedateTickerDown(oldReleaseDate, gameInfoIndex));
        }
        oldReleaseDate = releaseDates[gameInfoIndex];
    }

    public void UpdateVideo(int gameInfoIndex)
    {
        backgroundVideo.clip = backgroundVideos[gameInfoIndex];
        backgroundVideo.Play();
    }

}
