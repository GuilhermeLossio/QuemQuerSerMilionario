using System.Collections.Generic;

[System.Serializable]
public class Awnsers
{
    public int resposta;
    public string pergunta;

    public string resposta1;
    public string resposta2;
    public string resposta3;
    public string resposta4;
}

[System.Serializable]
public class AllAwnsers
{
    //public Awnsers[] awnsers;

    //public List<Awnsers> awnsers;
    public List<Awnsers> awnsers = new List<Awnsers>();
}

//
//     Code made by: Guilherme Lossio
//  Please if use this code, or some part of it, give me the credits.
//  My game portifolio is at: https://sacminerva.itch.io/
//  If want to contract me for some job call me at: Guilhermelossio@gmail.com
//
//