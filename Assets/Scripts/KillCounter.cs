using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text killCountText;
    private int killCount = 0;

    public void IncrementKillCount()
    {
        killCount++;
        UpdateKillCountText();
    }

    private void UpdateKillCountText()
    {
        killCountText.text =  killCount.ToString();
    }
}
