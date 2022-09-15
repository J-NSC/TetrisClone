using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class HudController : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highScore;
    public Board board;



    void Start()
    {
        
    }

    void Update()
    {
        score.text = board.score.ToString();
        highScore.text = board.highScore.ToString();

    }



}
