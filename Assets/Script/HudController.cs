using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class HudController : MonoBehaviour
{


    public TMP_Text highScore;
    public Board board;



    void Start()
    {
        
    }

    void Update()
    {
        highScore.text = board.score.ToString();

    }

}
