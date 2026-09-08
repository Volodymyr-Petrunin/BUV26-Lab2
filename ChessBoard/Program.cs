using ChessBoard.domain;
using ChessBoard.service;

namespace ChessBoard;

internal static class Program {
    private const string BoardSizeQuestion = "Hur stor bräde?";

    private const string BlackCellQuestion = "Hur ska svarta rutor se ut?";

    private const string WhiteCellQuestion = "Hur ska vita rutor se ut?";

    private const string KingQuestion = "Hur ska pjäsen se ut?";

    private const string KingCellQuestion = "Var ska pjästen stå?";

    private static void Main(string[] args) {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine(BoardSizeQuestion);
        int boardSize = int.Parse(Console.ReadLine());

        char blackCell = GetValidCharInput(BlackCellQuestion);

        char whiteCell = GetValidCharInput(WhiteCellQuestion);

        char kingCell = GetValidCharInput(KingQuestion);

        Console.WriteLine(KingCellQuestion);
        string kingPosition = Console.ReadLine();

        var printService = new PrintService(boardSize, blackCell, whiteCell, kingCell, kingPosition);
        var boardService = new BoardService();

        List<Cell> cells = boardService.FillCellsList(boardSize);

        printService.PrintChessBoard(cells);
    }

    private static char GetValidCharInput(string question) {
        Console.WriteLine(question);

        char result;

        while (!char.TryParse(Console.ReadLine(), out result)) {
            Console.WriteLine("Please enter a valid character.");
            Console.WriteLine(Enumerable.Repeat('-', Console.BufferWidth).ToArray());
            Console.WriteLine(question);
        }

        return result;
    }
}