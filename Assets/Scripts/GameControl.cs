using System.Collections;
using System.Collections.Generic;
using GameSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public static int GameLanguage = 1; // 0: Spanish, 1: English

    public static Turn ActualTurn = Turn.White;
    public static Phase ActualPhase = Phase.Neutron;
    [SerializeField] private TextMeshProUGUI lastWinner;
    private static GameControl instance;
    
    public static GameControl GetInstance() {
        if (instance == null) {
            instance = FindObjectOfType<GameControl>();
        }
        return instance;
    }

    void Awake() {
        LanguageManager.LoadLanguagesFile("Languages");
    }

    public static void BeginGame() {
        SetActualTurn(Turn.White);
    }

    public static void SetActualTurn(Turn turn) {
        ActualTurn = turn;
        ActualPhase = Phase.Neutron;
        var neutron = Table.GetInstance().GetNeutron();
        Table.GetInstance().SetSelectedPiece(neutron);
        TurnPointer.GetInstance().SetPosition(turn);
        neutron.DisplayMovementArrows();
    }

    private static void PlayAgain() {
        Table.GetInstance().ResetTable();
        BeginGame();
    }

    public void ChangeToTokenPhase() {
        ActualPhase = Phase.Token;
        Table.GetInstance().SetSelectedPiece(null);
        CheckWinCondition();
    }

    private void CheckWinCondition() {
        var neutronRow = Table.GetInstance().GetNeutron().GetRow();
        if (neutronRow is not (0 or 4)) return;
        lastWinner.GetComponent<LoadTranslation_TMP>().SetTextInKeyLanguage(neutronRow is 4 ? "Blanco" : "Negro");
        PlayAgain();
    }
    
}
