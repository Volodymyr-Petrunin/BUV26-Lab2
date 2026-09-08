using System.Text;
using ChessBoard.domain;

namespace ChessBoard.service;

public class PrintService(int boardSize, char blackCell, char whiteCell, char kingCell, string kingPosition) {
    public void PrintChessBoard(List<Cell> cells) {
        ValidateKingPosition(cells);
        
        var stringBuilder = new StringBuilder();

        for (int currentIndex = 0; currentIndex < cells.Count; currentIndex++) {
            var cell = cells[currentIndex];
            
            if (currentIndex % boardSize == 0 && currentIndex != 0) {
                stringBuilder.AppendLine();
            }

            stringBuilder.Append(SetKingOnBoard(cell, kingCell.ToString()));
        }

        Console.WriteLine(stringBuilder);
    }

    private void ValidateKingPosition(List<Cell> cells) {
        bool exist = cells.Any(cell => 
            MergeCellColumnNameAndNumber(cell.ColumnName, cell.ColumnNumber)
                .Equals(kingPosition, StringComparison.OrdinalIgnoreCase));

        if (!exist) {
            throw new ArgumentException($"King position {kingPosition} is invalid");
        }
    }

    private string SetKingOnBoard(Cell cell, string king) {
        string cellName = MergeCellColumnNameAndNumber(cell.ColumnName, cell.ColumnNumber);
        
        if (cellName.Equals(kingPosition, StringComparison.OrdinalIgnoreCase)) {
            return king;
        }

        return SetColor(cell.CellColor);
    }

    private string MergeCellColumnNameAndNumber(string columnName, int columnNumber) {
        return columnName + columnNumber;
    }

    private string SetColor(CellColor cellColor) {
        return cellColor == CellColor.Black ? blackCell.ToString() : whiteCell.ToString();
    }
}