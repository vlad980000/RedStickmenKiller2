using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillingPlayerData : MonoBehaviour
{
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;

    public void Set(LeaderboardPlayer player)
    {
        _rank.text = player.Rank.ToString();

        if (player.Rank == 0)
            _rank.text = "-";

        _name.text = player.Name.ToString();
        _score.text = player.Score.ToString();
    }
}
