using UnityEngine;
using System.Collections;


public class Pergunta {

    public string Tema { get; set; }
    public Texture2D Imagem { get; set; }
    public string Texto { get; set; }
    public string[] Respostas { get; set; }
    public int RespostaCerta { get; set; }
}
