namespace ChessBoard.domain;

public class Cell(CellColor cellColor, string lineName, int columnName)
{
    public CellColor CellColor { get; set; } = cellColor;

    public string ColumnName { get; set; } = lineName;

    public int ColumnNumber { get; set; } = columnName;
}