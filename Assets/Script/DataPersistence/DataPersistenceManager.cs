using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistenceManager inst {get; private set;}


    private void Awake() {
        if(inst != null){
            Debug.LogError("save nao encontrado");
        }

        inst = this;
    }

    private void Start() {
        LoadGame();
    }

    public void newGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){
        if(this.gameData = null){
            Debug.Log("no data was found");
            newGame();
        }
    }

    public void SavaGame(){

    }

    private void OnApplicationQuit() {
        SavaGame();
    }
}
