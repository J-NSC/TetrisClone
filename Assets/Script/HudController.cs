using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class HudController : MonoBehaviour
{
    public TMP_Text score;
<<<<<<< Updated upstream
    public Board board;

=======
    public TMP_Text highScore;
    public Board board;



>>>>>>> Stashed changes
    void Start()
    {
        
    }

    void Update()
    {
        score.text = board.score.ToString();
<<<<<<< Updated upstream
    }

=======
        highScore.text = board.highScore.ToString();

    }



>>>>>>> Stashed changes
}
