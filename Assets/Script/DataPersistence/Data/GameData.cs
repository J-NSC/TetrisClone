using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public int score;

    public GameData (){
        this.score = 0;
    }

}
