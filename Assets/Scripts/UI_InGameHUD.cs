using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_InGameHUD : MonoBehaviour
{

    [SerializeField] GameManagerSO gameManager;
    [SerializeField] TMP_Text coinTextObject;

    private void Update()
    {
        coinTextObject.text = $"Coins: {gameManager.coins}";
    }
}
