using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Player {
    None,
    Player1,
    Player2,
}

public struct Piece {
    public enum Movement {
        Orthagonal,
        Diagonal,
    }

    public Player owner;
    public Vector3Int position;
    public Movement move;
    public Sprite spr;
}

public struct Slider {
    public Player owner;
    public Vector3Int position;
    public Sprite spr;
}

public class Coercion_Game : MonoBehaviour {
    public int width = 10;
    public int height = 10;
    int playerPieces;
    Piece[] boardPieces;
    Slider[] borderPieces = new Slider[2];

    public Sprite p1Orth;
    public Sprite p1Diag;
    public Sprite p1Slid;
    public Sprite p2Orth;
    public Sprite p2Diag;
    public Sprite p2Slid;

    private void Start() {
        initialize();
    }

    // Should add board generation in here as well, but I am not doing that yet
    public void initialize() {
        Camera.main.transform.position = new Vector3(width / 2f, height / 2f, -10f);
        playerPieces = (width - 2) * 2;
        boardPieces = new Piece[playerPieces * 2];

        for (int i = 0; i < playerPieces; i++) {
            if (i < playerPieces / 2) {
                boardPieces[i].owner = Player.Player1;
                if (i < playerPieces / 4) {
                    boardPieces[i].position = new Vector3Int(i + 1, 1, 0);
                    boardPieces[i].move = Piece.Movement.Orthagonal;
                    boardPieces[i].spr = p1Orth;
                }
                else {
                    boardPieces[i].position = new Vector3Int(i + 1, 2, 0);
                    boardPieces[i].move = Piece.Movement.Diagonal;
                    boardPieces[i].spr = p1Diag;
                }
            }
            else {
                boardPieces[i].owner = Player.Player1;
                if (i < playerPieces * 3 / 4) {
                    boardPieces[i].position = new Vector3Int(i + 1, height - 3, 0);
                    boardPieces[i].move = Piece.Movement.Diagonal;
                    boardPieces[i].spr = p2Diag;
                }
                else {
                    boardPieces[i].position = new Vector3Int(i + 1, height - 2, 0);
                    boardPieces[i].move = Piece.Movement.Orthagonal;
                    boardPieces[i].spr = p2Orth;
                }
            }
        }

        borderPieces[0].owner = Player.Player1;
        borderPieces[0].position = new Vector3Int(0, width - 1, 0);
        borderPieces[0].spr = p1Slid;
        borderPieces[1].owner = Player.Player2;
        borderPieces[1].position = new Vector3Int(height - 1, 0, 0);
        borderPieces[1].spr = p2Slid;
    }
}