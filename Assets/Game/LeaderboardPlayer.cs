using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardPlayer : MonoBehaviour
{
    public string Name { get; private set; }
    public int Rank { get; private set; }
    public int Score { get; private set; }

    public void SetValue(string name, int rank, int score)
    {
        Name = name;
        Rank = rank;
        Score = score;
    }
}
