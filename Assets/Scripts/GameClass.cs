using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameClass : MonoBehaviour
{
    private int liveAmount;
    public int atualLocation;
    private GameObject audioData1;
    private GameObject audioData2;

    [SerializeField] private int  resposta;
    [SerializeField] private TextMeshProUGUI  res1;
    [SerializeField] private TextMeshProUGUI  res2;
    [SerializeField] private TextMeshProUGUI  res3;
    [SerializeField] private TextMeshProUGUI  res4;
    [SerializeField] private TextMeshProUGUI  ask;

    public TextAsset jsonFile;
    public AllAwnsers allMyAwnsers = new AllAwnsers();
    public Slider scoreSlider;
    private Transform awnsersArea;

    [SerializeField] private TextMeshProUGUI  pontuac;
    [SerializeField] private TextMeshProUGUI  victoryStatus;
    private GameObject endGameMenu;
 
    void Start()
    {

        //Here we going to get the text  areas
        res1 = GameObject.Find("Res1").GetComponent<TextMeshProUGUI >();
        res2 = GameObject.Find("Res2").GetComponent<TextMeshProUGUI >();
        res3 = GameObject.Find("Res3").GetComponent<TextMeshProUGUI >();
        res4 = GameObject.Find("Res4").GetComponent<TextMeshProUGUI >();
        ask = GameObject.Find("Ask").GetComponent<TextMeshProUGUI >();

        awnsersArea = GameObject.Find("AreaDasRespostas").transform;
        allMyAwnsers = JsonUtility.FromJson<AllAwnsers>(jsonFile.text);


        ResetCenary();

        audioData1 = GameObject.Find("QuePena");
        audioData2 = GameObject.Find("TaTranquilo");

        endGameMenu = GameObject.Find("EndGamePanel");
        pontuac = GameObject.Find("PontuacFInal").GetComponent<TextMeshProUGUI >();
        victoryStatus = GameObject.Find("VictoryStatus").GetComponent<TextMeshProUGUI >();
        endGameMenu.SetActive(false);
    }


    public void ResetCenary()
    {
        Debug.Log(allMyAwnsers.awnsers.Count);


        atualLocation = Random.Range(0, allMyAwnsers.awnsers.Count - 1);
        res1.text = allMyAwnsers.awnsers[atualLocation].resposta1;
        res2.text = allMyAwnsers.awnsers[atualLocation].resposta2;
        res3.text = allMyAwnsers.awnsers[atualLocation].resposta3;
        res4.text = allMyAwnsers.awnsers[atualLocation].resposta4;
        ask.text = allMyAwnsers.awnsers[atualLocation].pergunta;
        resposta = allMyAwnsers.awnsers[atualLocation].resposta;
        changeButtonStatus();
    }

    public void Responda(string respostaDada)
    {
        int i =  int.Parse(respostaDada);
        if(i == resposta)
        {
            //win
            scoreSlider.value += 1;
            audioData2.GetComponent<AudioSource>().Play();
            Invoke("ResetCenary", 3.0f);
        }
        else
        {
            //loss
            scoreSlider.value -= 1;
            audioData1.GetComponent<AudioSource>().Play();
            Invoke("ResetCenary", 3.0f);

        }
        verifyLoss();
        allMyAwnsers.awnsers.RemoveAt(0);

        changeButtonStatus();

    }


    public void verifyLoss()
    {
        if(scoreSlider.value == 0)
        {
            //perdeu o jogo
            endGameMenu.SetActive(true);
            victoryStatus.text = "Você perdeu!";
            

        }
        else if(scoreSlider.value == 10 || allMyAwnsers.awnsers.Count == 0)
        {
            //Fim de jogo
            victoryStatus.text = "Você ganhou!";
            endGameMenu.SetActive(true);
        }
        pontuac.text = liveAmount.ToString();
    }



    private void changeButtonStatus()
    {
        bool statusOfAllButtons = !awnsersArea.GetChild(0).gameObject.GetComponent<Button>().interactable;

        awnsersArea.GetChild(0).gameObject.GetComponent<Button>().interactable = statusOfAllButtons;
        awnsersArea.GetChild(1).gameObject.GetComponent<Button>().interactable = statusOfAllButtons;
        awnsersArea.GetChild(2).gameObject.GetComponent<Button>().interactable = statusOfAllButtons;
        awnsersArea.GetChild(3).gameObject.GetComponent<Button>().interactable = statusOfAllButtons;
    }
}



//
//     Code made by: Guilherme Lossio
//  Please if use this code, or some part of it, give me the credits.
//  My game portifolio is at: https://sacminerva.itch.io/
//  If want to contract me for some job call me at: Guilhermelossio@gmail.com
//
//