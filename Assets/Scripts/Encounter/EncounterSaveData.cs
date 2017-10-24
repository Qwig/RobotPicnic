using UnityEngine;

public class EncounterSaveData
{
    public GameObject[,] map { get; set; }
    public int PlayerX { get; set; }
    public int PlayerY { get; set; }
    public int EnemyX { get; set; }
    public int EnemyY { get; set; }
    public int PlayerOldX { get; set; }
    public int PlayerOldY { get; set; }
    public string battleType { get; set; }
    public bool BattleVictory { get; set; }

    public EncounterSaveData()
    {
        EnemyX = 9;
        EnemyY = 9;
    }
}
