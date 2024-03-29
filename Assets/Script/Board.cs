using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Tilemap tilemap {get; private set;}
    public Piece activePiece {get; private set;}
    public TetrominoData[] tetrominos;
    public Vector3Int spwanPosition;
    public Vector2Int boardSize = new Vector2Int(10, 20);


    public int score;
    public int highScore =0 ;

    public RectInt Bounds{
        get {
            Vector2Int position = new Vector2Int(-this.boardSize.x / 2, -this.boardSize.y / 2);
            return new RectInt(position, this.boardSize);
        }
    }

    private void Awake() {
        this.tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();
        for (int i = 0; i < this.tetrominos.Length; i++)
        {   
            this.tetrominos[i].Initialize();
        }
    }


    private void Start() {
        SpawnPiece();
        // highScore = SaveScore.get("highScore");
    }

    private void Update() {
        Debug.Log(score);
    }

    public void SpawnPiece(){
        int random = Random.Range(0, this.tetrominos.Length);
        TetrominoData data = this.tetrominos[random];

        this.activePiece.Initialize(this, this.spwanPosition ,data);

        if(isValidPosition(this.activePiece, this.spwanPosition)){
            Set(this.activePiece);
        }else{
            GameOver(); 
        }
    }   

    private void GameOver(){
        this.tilemap.ClearAllTiles();
        score = 0;
        if(highScore > score){
            highScore = score; 
            // SaveScore.save("highScore", highScore);
        }
    }

    public void Set(Piece piece){
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(Piece piece){
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, null);
        }
    }

    public bool isValidPosition(Piece piece , Vector3Int position){

        RectInt bounds = this.Bounds; 

        for(int i = 0 ; i < piece.cells.Length; i++){
            Vector3Int tilePosition = piece.cells[i] + position;

            if(!bounds.Contains((Vector2Int)tilePosition)){
                return false;    
            }

            if(this.tilemap.HasTile(tilePosition)){
                return false; 
            }
        }

        return true; 
    }

    public void  ClearLines(){
        RectInt bounds = this.Bounds;
        int row = bounds.yMin;

        while(row < bounds.yMax){
            if(isLineFull(row)){
                LineClear(row);
                score += 40;
            }else {
                row ++;
            }
        }
    }

    private bool isLineFull(int row){
        RectInt bounds = this.Bounds;

        for(int col = bounds.xMin; col < bounds.xMax; col++){
            Vector3Int position = new Vector3Int(col , row, 0);

            if(!this.tilemap.HasTile(position)){
                return false;
            }
        }

        return true;
    }

    private void LineClear(int row){
        RectInt bounds = this.Bounds;

        for(int col = bounds.xMin; col < bounds.xMax; col++){
            Vector3Int position = new Vector3Int(col , row, 0);
            this.tilemap.SetTile(position,null);
        }

        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col , row + 1, 0);
                TileBase above = this.tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                this.tilemap.SetTile(position, above);
            }
            row++;
        }
    }

}
