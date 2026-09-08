using ChessBoard.domain;

namespace ChessBoard.service;

public class BoardService {
    public List<Cell> FillCellsList(int boardSize) {
        var cells = new List<Cell>(boardSize * boardSize);
        
        for (int row = 1; row <= boardSize; row++) {
            for (int column = 1; column <= boardSize; column++) {
                if ((column + row) % 2 != 0) {
                    cells.Add(new Cell(CellColor.Black, GetColumnName(column), row));
                } else {
                    cells.Add(new Cell(CellColor.White, GetColumnName(column), row));
                }
            }
        }
        
        return cells;
    }
    
    private static string GetColumnName(int index) {
        string columnName = "";
        
        while (index > 0) {
            int modulo = (index - 1) % 26;
            
            columnName = (char) ('A' + modulo) + columnName;
            
            index = (index - modulo) / 26;
        }
        
        return columnName;
    }
}