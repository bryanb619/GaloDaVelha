public class Board 
{
    private string[,] board;


    public Board(string[,] board)
    {
        SetBoard(board);
    }
    
    private void SetBoard(string[,] board)
    {
        this.board = board;
    }

    public string[,] GetBoard()
    {
        return board;
    }

}