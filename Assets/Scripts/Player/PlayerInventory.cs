using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int keyCount = 0;
    public int coinCount = 0;
    public Text keyCountText;
    public Text coinCountText;

    void Start()
    {
        UpdateKeyCountText();
        UpdateCoinCountText();
    }

    public void AddKey()
    {
        keyCount++;
        UpdateKeyCountText();

    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinCountText();
    }
    void UpdateCoinCountText()
    {
        coinCountText.text = " " + coinCount;
    }

    void UpdateKeyCountText()
    {
        keyCountText.text = " " + keyCount;
    }
}