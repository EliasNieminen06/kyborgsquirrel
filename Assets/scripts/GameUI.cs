using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI nutsText;
    public TextMeshProUGUI healtgText;
    public TextMeshProUGUI roundsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nutsText.text = "Nuts: " + Squirrel.instance.nuts.ToString();
        healtgText.text = "Health: " + Treee.instance.health.ToString();
        roundsText.text = "Round: " + EnemySpawner.instance.currentRound.ToString() + "/" + EnemySpawner.instance.rounds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        nutsText.text = "Nuts: " + Squirrel.instance.nuts.ToString();
        healtgText.text = "Health: " + Treee.instance.health.ToString();
        roundsText.text = "Round: " + EnemySpawner.instance.currentRound.ToString() + "/" + EnemySpawner.instance.rounds.ToString();
    }
}
