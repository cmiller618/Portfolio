namespace Chess_API.Models;

public class Board
{
    public Piece[,] ChessBoard { get; set; } = new Piece[8, 8];
    public List<string> LastMove { get; set; } = new List<string>();

    private int whitePawn = 1;
    private int blackPawn = -1;
    private int whiteKnight = 3;
    private int blackKnight = -3;
    private int whiteBishop = 3;
    private int blackBishop = -3;
    private int whiteRook = 5;
    private int blackRook = -5;
    private int whiteQueen = 9;
    private int blackQueen = -9;
    private int whiteKing = 90;
    private int blackKing = -90;


    public Piece[,] StartingBoard()
    {
        ChessBoard[0, 0] = new Rook
        {
            IsWhite = true,
            PieceValue = whiteRook,
            PieceFile = "./Board/Pieces/white_rook.png"
        };
        ChessBoard[1, 0] = new Knight
        {
            IsWhite = true,
            PieceValue = whiteKnight,
            PieceFile = "./Board/Pieces/white_knight.png"
        };
        ChessBoard[2, 0] = new Bishop
        {
            IsWhite = true,
            PieceValue = whiteBishop,
            PieceFile = "./Board/Pieces/white_bishop.png"
        };
        ChessBoard[3, 0] = new Queen
        {
            IsWhite = true,
            PieceValue = whiteQueen,
            PieceFile = "./Board/Pieces/white_queen.png"
        };
        ChessBoard[4, 0] = new King
        {
            IsWhite = true,
            PieceValue = whiteKing,
            PieceFile = "./Board/Pieces/white_king.png"
        };
        ChessBoard[5, 0] = new Bishop
        {
            IsWhite = true,
            PieceValue = whiteBishop,
            PieceFile = "./Board/Pieces/white_bishop.png"
        };
        ChessBoard[6, 0] = new Knight
        {
            IsWhite = true,
            PieceValue = whiteKnight,
            PieceFile = "./Board/Pieces/white_knight.png"
        };
        ChessBoard[7, 0] = new Rook
        {
            IsWhite = true,
            PieceValue = whiteRook,
            PieceFile = "./Board/Pieces/white_rook.png"
        };

        ChessBoard[0, 7] = new Rook
        {
            IsWhite = false,
            PieceValue = blackRook,
            PieceFile = "./Board/Pieces/black_rook.png"
        };
        ChessBoard[1, 7] = new Knight
        {
            IsWhite = false,
            PieceValue = blackKnight,
            PieceFile = "./Board/Pieces/black_knight.png"
        };
        ChessBoard[2, 7] = new Bishop
        {
            IsWhite = false,
            PieceValue = blackBishop,
            PieceFile = "./Board/Pieces/black_bishop.png"
        };
        ChessBoard[3, 7] = new King
        {
            IsWhite = false,
            PieceValue = blackKing,
            PieceFile = "./Board/Pieces/black_king.png"
        };
        ChessBoard[4, 7] = new Queen
        {
            IsWhite = false,
            PieceValue = blackQueen,
            PieceFile = "./Board/Pieces/black_queen.png"
        };
        ChessBoard[5, 7] = new Bishop
        {
            IsWhite = false,
            PieceValue = blackBishop,
            PieceFile = "./Board/Pieces/black_bishop.png"
        };
        ChessBoard[6, 7] = new Knight
        {
            IsWhite = false,
            PieceValue = blackKnight,
            PieceFile = "./Board/Pieces/black_knight.png"
        };
        ChessBoard[7, 7] = new Rook
        {
            IsWhite = false,
            PieceValue = blackRook,
            PieceFile = "./Board/Pieces/black_rook.png"
        };

        for (int i = 0; i <= 7; i++)
        {
            ChessBoard[i, 1] = new Pawn
            {
                IsWhite = true,
                PieceValue = whitePawn,
                PieceFile = "./Board/Pieces/white_pawn.png"
            };
            ChessBoard[i, 6] = new Pawn
            {
                IsWhite = false,
                PieceValue = blackPawn,
                PieceFile = "./Board/Pieces/black_pawn.png"
            };
        }
        return ChessBoard;
    }
}
