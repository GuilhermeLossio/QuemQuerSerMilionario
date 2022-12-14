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