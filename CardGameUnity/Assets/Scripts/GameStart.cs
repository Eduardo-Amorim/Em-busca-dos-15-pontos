using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    void Start()
    {
        MasterScr.Panel = GameObject.Find("Panel");
        MasterScr.ResultadoResp = GameObject.Find("ResultadoResp");
        MasterScr.Card = GameObject.Find("Card");
        MasterScr.BotCard = GameObject.Find("BotCard");
        MasterScr.Hand = GameObject.Find("Hand");
        MasterScr.BotHand = GameObject.Find("BotHand");
        MasterScr.Overlay = GameObject.Find("Overlay");
        MasterScr.OverlayBotAction = GameObject.Find("OverlayBotAction");
        MasterScr.Pergunta = GameObject.Find("Pergunta");
        MasterScr.RespostaA = GameObject.Find("RespAText");
        MasterScr.RespostaB = GameObject.Find("RespBText");
        MasterScr.RespostaC = GameObject.Find("RespCText");
        MasterScr.RespostaD = GameObject.Find("RespDText");
        MasterScr.VidaBot = GameObject.Find("VidaBot");
        MasterScr.VidaJog = GameObject.Find("VidaJog");
        MasterScr.Jogador = new Player();
        MasterScr.Bot = new Player();

        CarregarTemas();


        List<Pergunta> perguntasValidas = new List<Pergunta>();
        perguntasValidas.AddRange(MasterScr.PerguntasCarregadas);

        for (int i = 0; i < 5; i++)
        {
            var novaCarta = Instantiate(MasterScr.Card);
            novaCarta.name += i;
            var drag = novaCarta.GetComponent<Draggable>();

            novaCarta.transform.parent = MasterScr.Card.transform.parent;
            drag.parentToReturnTo = MasterScr.Hand.transform;

            novaCarta.transform.localScale = MasterScr.Card.transform.localScale;

            Pergunta perguntaAleatoria = perguntasValidas[Random.Range(0, perguntasValidas.Count)];
            perguntasValidas.Remove(perguntaAleatoria);

            var sprt = Sprite.Create(perguntaAleatoria.Imagem, new Rect(0, 0, perguntaAleatoria.Imagem.width, perguntaAleatoria.Imagem.height), new Vector2(.5f, .5f));

            novaCarta.GetComponent<CanvasRenderer>().SetTexture(perguntaAleatoria.Imagem);

            var images = novaCarta.GetComponentsInChildren<Image>();

            foreach (Image image in images)
            {
                image.sprite = sprt;
            }


            novaCarta.AddComponent<CardScr>().pergunta = perguntaAleatoria;
        }

        for (int i = 0; i < 5; i++)
        {
            var novaCarta = Instantiate(MasterScr.BotCard);
            novaCarta.name += i;
            var drag = novaCarta.GetComponent<Draggable>();

            novaCarta.transform.parent = MasterScr.BotCard.transform.parent;
            drag.parentToReturnTo = MasterScr.BotHand.transform;

            novaCarta.transform.localScale = MasterScr.BotCard.transform.localScale;

            Pergunta perguntaAleatoria = perguntasValidas[Random.Range(0, perguntasValidas.Count)];
            perguntasValidas.Remove(perguntaAleatoria);

            novaCarta.AddComponent<CardScr>().pergunta = perguntaAleatoria;
        }

        MasterScr.Panel.SetActive(false);
        MasterScr.ResultadoResp.SetActive(false);
        MasterScr.Card.SetActive(false);
        MasterScr.BotCard.SetActive(false);
        MasterScr.Overlay.SetActive(false);
        MasterScr.OverlayBotAction.SetActive(false);
    }

    void CarregarTemas()
    {
        foreach (var tema in MasterScr.Temas)
        {
            string nomeTema = tema[0];
            string arquivoTema = tema[1];
            string imagemTema = tema[2];

            string arquivo = (Resources.Load("Temas/" + arquivoTema) as TextAsset).text;

            string[] linhas = arquivo.Split('\r');

            foreach (var linha in linhas)
            {
                string[] colunas = linha.Split(';');
                string pergunta = colunas[0];
                string respA = colunas[1];
                string respB = colunas[2];
                string respC = colunas[3];
                string respD = colunas[4];
                int respCerta = int.Parse(colunas[5]);

                Pergunta p = new Pergunta();

                p.Texto = pergunta;
                p.Respostas = new string[] { respA, respB, respC, respD };
                p.RespostaCerta = respCerta;
                p.Imagem = (Resources.Load("Imagens/" + imagemTema) as Texture2D);
                p.Tema = nomeTema;
                    
                MasterScr.PerguntasCarregadas.Add(p);
            }
        }
    }
}
