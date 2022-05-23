using HobbyTeamManager.Models;

namespace HobbyTeamManager.Utilities;

public class PlayerGaleryCalculator
{
    public IList<Player>? List { get; set; }
    public int Count => List?.Count ?? 0;
    public int ColumnsPerRow { get; set; } = 10;
    public int Rows => (Count / ColumnsPerRow) + 1;
    public int Columns => (Count / Rows) + 1;
    public int Index { get; set; } = 0;
}
