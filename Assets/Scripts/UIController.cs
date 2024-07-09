using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController _instance;

    // https://www.dafont.com/
    //FIND  A FONT A APPLY IT TO THE TEXTMSHPRO 10 pts
    //Aplique el  airstrikelaser de este link https://www.dafont.com/es/airstrike.font

    [SerializeField]
    TextMeshProUGUI scoreTextBox;

    [SerializeField]
    Transform livesContainer;

    bool _hasLives = true;

    private void Awake()
    {
        //IMPLEMENT Singlenton(Instance) to Invoke IncreaseScore 10 pts
        _instance = this;
    }

    public void IncreaseScore(float points)
    {
        float score = float.Parse(scoreTextBox.text);
        score += points;
        scoreTextBox.text = score.ToString();
    }

    public void DecreaseLives()
    {
        int maxLiveNumber = 0;
        Image[] lives = livesContainer.GetComponentsInChildren<Image>();
        Image maxLiveImg = null;

        foreach (Image image in lives)
        {
            if (image.name.StartsWith("Live-") && image.enabled) 
            {
                int liveNumber = int.Parse(image.name.Remove(0,5));
                if(maxLiveNumber <= liveNumber)
                {
                    maxLiveNumber = liveNumber;
                    maxLiveImg = image;
                }
            }
        }
              
        if(maxLiveImg != null) 
        {
            maxLiveImg.enabled = false;
        }

        _hasLives = maxLiveNumber > 0;
    }

    public bool HasLives()
    {
        return _hasLives;
    }

    public static UIController Instance
    {
        get { return _instance; }
    }

    public int GetLives()
    {
        Image[] lives = livesContainer.GetComponentsInChildren<Image>();
        int livesCount = 0;

        foreach (Image image in lives)
        {
            if (image.name.StartsWith("Live-") && image.enabled)
            {
                livesCount++;
            }
        }
        return livesCount;
    }

}
