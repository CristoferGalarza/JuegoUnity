using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Llamar al scriptable object
    private PlayerInfo playerInfo;
    public TextMeshProUGUI scoreText;
    void Awake()
    {
        playerInfo = Resources.Load<PlayerInfo>("PlayerInfo");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerInfo.score + "";
    }
}
