using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static int coin = 0;
    void Start()
    {
        coin = GameSystem.loadGame().Coin;
        GameObject.FindGameObjectWithTag("Coin").GetComponent<TextMeshProUGUI>().SetText(coin.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getCoin()
    {
        return coin;
    }
    public int addCoin(int coin)
    {
        CoinManager.coin += coin;
        GameObject.FindGameObjectWithTag("Coin").GetComponent<TextMeshProUGUI>().SetText(CoinManager.coin.ToString());
        PlayerEntity player = GameSystem.loadGame();
        player.Coin = CoinManager.coin;
        GameSystem.saveGame(player);
        return CoinManager.coin;
    }
}
