using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterScr : MonoBehaviour
{

    public static GameObject Card;
    public static GameObject BotCard;
    public static GameObject Hand;
    public static GameObject BotHand;
    public static GameObject Panel;
    public static GameObject ResultadoResp;
    public static GameObject Overlay;
    public static GameObject OverlayBotAction;
    public static GameObject Pergunta;
    public static GameObject RespostaA;
    public static GameObject RespostaB;
    public static GameObject RespostaC;
    public static GameObject RespostaD;

    public static GameObject VidaBot;
    public static GameObject VidaJog;
    public static Player Jogador;
    public static Player Bot;

    public static Pergunta PerguntaAtual;

    public static string[][] Temas =
    new string[][]{
        new string[] { "Idade Moderna", "IdMod", "Tema_Franca" },
        new string[] { "Idade Media", "IdMed", "Tema_IdadeMedia" },
        new string[] { "Antiguidade Ocidental", "AntOc", "Tema_AntiguidadeOcidental" },
        new string[] { "Antiguidade Oriental", "AntOr", "Tema_AntiguidadeOriental" },
        new string[] { "Pre-Historia", "PreHis", "Tema_PreHistoria" }
    };
    public static List<Pergunta> PerguntasCarregadas = new List<Pergunta>();
}
