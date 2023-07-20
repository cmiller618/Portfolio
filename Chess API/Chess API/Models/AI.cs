namespace Chess_API.Models;

public class AI
{
    public bool IsWhite { get; set; }

    public List<int> BestMovesValues { get; set; }

    public int Index { get; set; }

    public bool GenerateBestMoves(Board board)
    {
        BestMovesValues = new List<int>();
        List<(int, int, int, int)> validMoves = new List<(int, int, int, int)>();
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (board.ChessBoard[x, y] != null && board.ChessBoard[x, y].IsWhite && IsWhite)
                {
                    BestMovesValues.AddRange(BestMoves(x, y, board));
                    validMoves.AddRange(FindValidMoves(x, y, board));
                }
                else if (board.ChessBoard[x, y] != null && !board.ChessBoard[x, y].IsWhite && !IsWhite)
                {
                    BestMovesValues.AddRange(BestMoves(x, y, board));
                    validMoves.AddRange(FindValidMoves(x, y, board));
                }
            }
        }

        int depth = 0;
        if (BestMovesValues.Count <= 3)
        {
            depth = 1;
        }
        else if (BestMovesValues.Count <= 7)
        {
            depth = 2;
        }
        else if (BestMovesValues.Count <= 15)
        {
            depth = 3;
        }
        else if (BestMovesValues.Count <= 31)
        {
            depth = 4;
        }
        else if (BestMovesValues.Count <= 63)
        {
            depth = 5;
        }
        else if (BestMovesValues.Count <= 127)
        {
            depth = 6;
        }
        else
        {
            depth = 7;
        }

        var bestMove = alphaBeta(BestMovesValues[0], depth, -1000000, 1000000, true, BestMovesValues, 1, 2);

        return board.ChessBoard[validMoves[Index].Item1, validMoves[Index].Item2].Movement(validMoves[Index].Item1,
            validMoves[Index].Item2, validMoves[Index].Item3, validMoves[Index].Item4, board);
    }

    public int alphaBeta(int origin, int depth, int alpha, int beta, bool isMaximizing, List<int> findBestMove, int child1, int child2)
    {
        int value;
        if (depth == 0)
        {
            return origin;
        }

        if (isMaximizing)
        {
            value = alpha;
            for (int i = child1; i <= child2; i++)
            {
                if (i >= findBestMove.Count)
                {
                    return origin;
                }
                Index = i;
                value = Math.Max(value, alphaBeta(findBestMove[i], depth - 1, alpha, beta, false, findBestMove, i + i + 1, i + i + 2));
                alpha = Math.Max(alpha, value);
                if (value >= beta)
                {
                    break;
                }
            }
        }
        else
        {
            value = beta;
            for (int i = child1; i <= child2; i++)
            {
                if (i >= findBestMove.Count)
                {
                    return origin;
                }
                Index = i;
                value = Math.Min(value, alphaBeta(findBestMove[i], depth - 1, alpha, beta, true, findBestMove, i + i + 1, i + i + 2));
                beta = Math.Min(beta, value);
                if (value <= alpha)
                {
                    break;
                }
            }
        }
        for(int i = Index; i < findBestMove.Count; i++)
        {
            if (findBestMove[Index] == value)
            {
                Index = i;
                break;
            }
        }
        return value;
    }

    public List<int> BestMoves(int x, int y, Board board)
    {
        for(int col = 0; col < 8; col++)
        {
            for(int row = 0; row < 8; row++)
            {
                if(board.ChessBoard[x, y].ValidMovement(x, y, row, col, board))
                {
                    var movementValues = board.ChessBoard[x, y].GetEvaluationBoard(board);
                    int movementValue = movementValues[row, col];
                    int pieceValue = board.ChessBoard[x, y].PieceValue;
                    BestMovesValues.Add(movementValue + pieceValue);
                }
            }
        }
        return BestMovesValues;
    }

    public bool RandomizeMove(Board board)
    {
        List<(int, int, int, int)> validMoves = new List<(int, int, int, int)>();
        for(int y = 0; y < 8; y++)
        {
            for(int x = 0; x < 8; x++)
            {
                validMoves.AddRange(FindValidMoves(x, y, board));
            }
        }

        Random random = new Random();
        int index = random.Next(validMoves.Count);
        var randomMove = validMoves[index];
        return board.ChessBoard[randomMove.Item1, randomMove.Item2].Movement(randomMove.Item1, randomMove.Item2, randomMove.Item3, randomMove.Item4, board);

    }
    public List<(int, int, int, int)> FindValidMoves(int x, int y, Board board)
    {
        List<(int, int, int, int)> validMoves = new List<(int, int, int, int)>();

        if (board.ChessBoard[x, y] != null && board.ChessBoard[x, y].IsWhite && IsWhite)
        {
            validMoves.AddRange(CheckPiece(x, y, board));
        }

        else if (board.ChessBoard[x, y] != null && !board.ChessBoard[x, y].IsWhite && !IsWhite)
        {
            validMoves.AddRange(CheckPiece(x, y, board));
        }
            
        return validMoves;
    }

    public List<(int, int, int, int)> CheckPiece(int x, int y, Board board)
    {
        List<(int, int, int, int)> validMoves = new List<(int, int, int, int)>();
        Piece piece = board.ChessBoard[x, y];

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (piece.ValidMovement(x, y, col, row, board))
                {
                    validMoves.Add((x, y, col, row));
                }
            }
        }
        return validMoves;
    }



}
