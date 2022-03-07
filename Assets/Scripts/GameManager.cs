using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameUI gameUI;
    public GameAudio gameAudio;

        public int marcPlay1, marcPlay2;
    public System.Action onReset;
    public int maxScore = 5;


    private void Awake(){
        if(instance){
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            gameUI.onStartGame += onStartGame;
        }
    }

    private void OnDestroy() {
        gameUI.onStartGame -= onStartGame;
    }

    public void MarcadorAnotado(int id){

        if(id == 1){
            marcPlay1++;
        }

        if(id == 2){
            marcPlay2++;
        }

        gameUI.ActMarcador(marcPlay1, marcPlay2);
       gameUI.HighlighScore(id);
       CheckGanador();

    }

    private void CheckGanador(){
        int ganadorId = marcPlay1 == maxScore ? 1 : marcPlay2 == maxScore ? 2 : 0;

        if(ganadorId != 0){
            gameUI.FinJuego(ganadorId);
            gameAudio.PlayWinSound();
        }
        else
        {
            onReset?.Invoke();
            gameAudio.PlayScoreSound();

        }
    }

    private void onStartGame(){
        marcPlay1 = 0;
        marcPlay2 = 0;
        gameUI.ActMarcador(marcPlay1, marcPlay2);
    }

    }

