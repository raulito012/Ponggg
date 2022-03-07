using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
      public TextoMarcador marcPlayer1, marcPlayer2;
      public GameObject menuObject;
      public TextMeshProUGUI ganadorTexto;

      public System.Action onStartGame;


      
    public void ActMarcador(int marcPlay1, int marcPlay2){
        marcPlayer1.SetScore(marcPlay1);
        marcPlayer2.SetScore(marcPlay2);

    }

    public void HighlighScore(int id){
        if(id == 1)
            marcPlayer1.Highlight();
            else
            {
                marcPlayer2.Highlight();
            }
        }

    public void OnStartGameButtonClicked(){
        menuObject.SetActive(false);
        onStartGame?.Invoke();
        
    }


    public void FinJuego(int ganadorId){
        menuObject.SetActive(true);
        ganadorTexto.text = $"El Jugador {ganadorId} ha ganado!";
    }



}
