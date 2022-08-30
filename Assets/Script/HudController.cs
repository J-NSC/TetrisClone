using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class HudController : MonoBehaviour
{
    public TMP_Text score;
    public Board board;

    void Start()
    {
        
    }

    void Update()
    {
        score.text = board.score.ToString();
    }

}
