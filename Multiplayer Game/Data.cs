using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class Data
{
    private List<PlayerData> data = new List<PlayerData>();

    public void SetData(PlayerData _player)
    {
        data.Add(_player);
    }

    public void SetScore(string _id, int _score)
    {
        foreach(PlayerData playerData in data)
        {
            if (playerData.id == _id)
            {
                playerData.score = _score;
            }
        }
    }

    public PlayerData GetData(string _id)
    {
        PlayerData value = new PlayerData();

        foreach (PlayerData player in data)
        {
            if (player.id == _id)
            {
                value = player;
            }
        }

        return value;
    }

    public bool Login(PlayerData _player)
    {
        bool value = false;

        foreach (PlayerData dataPlayer in data)
        {
            if (dataPlayer.id == _player.id && dataPlayer.password == _player.password)
            {
                value = true;
            }
        }

        return value;
    }
}