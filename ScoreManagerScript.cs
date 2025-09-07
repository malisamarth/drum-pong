using TMPro;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour {

    public static ScoreManagerScript Instance { get; private set; }
    private BallScript ballScript;

    private int opponentScore = 0;
    private int playertScore = 0;
    private int scoreAmount = 1;

    [SerializeField] TextMeshProUGUI opponentScoreText;
    [SerializeField] TextMeshProUGUI playertScoreText;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        ballScript = BallScript.Instance.GetComponent<BallScript>();
        ballScript.addOpponentScore += BallScript_addOpponentScore;
        ballScript.addPlayertScore += BallScript_addPlayertScore;
        opponentScoreText.text = "0";
        playertScoreText.text = "0";
    }

    private void BallScript_addPlayertScore(object sender, System.EventArgs e) {
        playertScore += scoreAmount;
        playertScoreText.text = playertScore.ToString();
    }

    private void BallScript_addOpponentScore(object sender, System.EventArgs e) {
        opponentScore += scoreAmount;
        opponentScoreText.text = opponentScore.ToString();
    }


}
