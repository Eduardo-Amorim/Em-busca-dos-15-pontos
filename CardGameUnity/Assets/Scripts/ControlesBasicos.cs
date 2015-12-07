using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using System.Collections;


public class ControlesBasicos : MonoBehaviour {

    GameObject[] CartasBot;

    public void carregaCena(string nomeCena) {

        Application.LoadLevel(nomeCena);

    }
    public IEnumerator selecionarRespostaAcao(int botao)
    {
        if (botao == MasterScr.PerguntaAtual.RespostaCerta)
        {
            MasterScr.Bot.Vida -= 10;
            MasterScr.VidaBot.GetComponent<Text>().text = "Vida:" + MasterScr.Bot.Vida.ToString();
            MasterScr.ResultadoResp.GetComponent<Text>().text = "Certo! Voce causou 10 de dano.";
            MasterScr.ResultadoResp.SetActive(true);
            
        }
        else
        {
            MasterScr.Jogador.Vida -= 5;
            MasterScr.VidaJog.GetComponent<Text>().text = "Vida:" + MasterScr.Jogador.Vida.ToString();
            MasterScr.ResultadoResp.GetComponent<Text>().text = "Errado! Voce recebeu 5 de dano.";
            MasterScr.ResultadoResp.SetActive(true);
            
        }
        yield return new WaitForSeconds(3);
        MasterScr.ResultadoResp.SetActive(false);
        MasterScr.Panel.SetActive(false);
        MasterScr.Overlay.SetActive(false);

        if (MasterScr.Jogador.Vida <= 0)
        {
            MasterScr.ResultadoResp.GetComponent<Text>().text = "Você Perdeu!";
            MasterScr.ResultadoResp.SetActive(true);

            yield return new WaitForSeconds(5);

            Application.LoadLevel("Title_Scene");
            yield break;
        }
        else if (MasterScr.Bot.Vida <= 0)
        {
            MasterScr.ResultadoResp.GetComponent<Text>().text = "Você Venceu!";
            MasterScr.ResultadoResp.SetActive(true);

            yield return new WaitForSeconds(5);

            Application.LoadLevel("Title_Scene");
            yield break;
        }

        MasterScr.OverlayBotAction.SetActive(true);
        MasterScr.ResultadoResp.GetComponent<Text>().text = "Vez do Bot!";
        MasterScr.ResultadoResp.SetActive(true);
        yield return new WaitForSeconds(2);
        MasterScr.ResultadoResp.SetActive(false);
        CartasBot = GameObject.FindGameObjectsWithTag("BotCard");
        GameObject r = CartasBot[Random.Range(0, CartasBot.Length)];

        var pergunta = r.GetComponent<CardScr>().pergunta;
        MasterScr.PerguntaAtual = pergunta;
        MasterScr.Pergunta.GetComponent<Text>().text = pergunta.Texto;

        MasterScr.RespostaA.GetComponent<Text>().text = pergunta.Respostas[0];
        MasterScr.RespostaB.GetComponent<Text>().text = pergunta.Respostas[1];
        MasterScr.RespostaC.GetComponent<Text>().text = pergunta.Respostas[2];
        MasterScr.RespostaD.GetComponent<Text>().text = pergunta.Respostas[3];
        r.SetActive(false);
        MasterScr.Panel.SetActive(true);
        MasterScr.Overlay.SetActive(true);
        yield return new WaitForSeconds(3);
        int ChuteBot = Random.Range(1,4);
        if(ChuteBot == MasterScr.PerguntaAtual.RespostaCerta)
        {
            MasterScr.Jogador.Vida -= 10;
            MasterScr.VidaJog.GetComponent<Text>().text = "Vida:" + MasterScr.Jogador.Vida.ToString();
            MasterScr.ResultadoResp.GetComponent<Text>().text = "Bot Acertou! Voce recebeu 10 de dano.";
            MasterScr.ResultadoResp.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(2);
            ChuteBot = Random.Range(1, 4);
            if (ChuteBot == MasterScr.PerguntaAtual.RespostaCerta)
            {
                MasterScr.Jogador.Vida -= 10;
                MasterScr.VidaJog.GetComponent<Text>().text = "Vida:" + MasterScr.Jogador.Vida.ToString();
                MasterScr.ResultadoResp.GetComponent<Text>().text = "Bot Acertou! Voce recebeu 10 de dano.";
                MasterScr.ResultadoResp.SetActive(true);
            }
            else
            {
                MasterScr.Bot.Vida -= 5;
                MasterScr.VidaBot.GetComponent<Text>().text = "Vida:" + MasterScr.Bot.Vida.ToString();
                MasterScr.ResultadoResp.GetComponent<Text>().text = "Bot Errou! Bot recebeu 5 de dano.";
                MasterScr.ResultadoResp.SetActive(true);
            }

        }
        yield return new WaitForSeconds(3);
        MasterScr.ResultadoResp.SetActive(false);
        MasterScr.Panel.SetActive(false);
        MasterScr.Overlay.SetActive(false);
        MasterScr.OverlayBotAction.SetActive(false);

        if (MasterScr.Jogador.Vida <= 0)
        {
            MasterScr.ResultadoResp.GetComponent<Text>().text = "Você Perdeu!";
            MasterScr.ResultadoResp.SetActive(true);

            yield return new WaitForSeconds(5);

            Application.LoadLevel("Title_Scene");
            yield break;
        }
        else if (MasterScr.Bot.Vida <= 0)
        {
            MasterScr.ResultadoResp.GetComponent<Text>().text = "Você Venceu!";
            MasterScr.ResultadoResp.SetActive(true);

            yield return new WaitForSeconds(5);

            Application.LoadLevel("Title_Scene");
            yield break;
        }

        CartasBot = GameObject.FindGameObjectsWithTag("BotCard");
        if(CartasBot.Length == 0)
        {
            if (MasterScr.Jogador.Vida > MasterScr.Bot.Vida)
            {
                MasterScr.ResultadoResp.GetComponent<Text>().text = "Você Venceu!";
                MasterScr.ResultadoResp.SetActive(true);
            }
            else if (MasterScr.Jogador.Vida < MasterScr.Bot.Vida)
            {
                MasterScr.ResultadoResp.GetComponent<Text>().text = "Você Perdeu!";
                MasterScr.ResultadoResp.SetActive(true);
            }
            else
            {
                MasterScr.ResultadoResp.GetComponent<Text>().text = "Empate!!";
                MasterScr.ResultadoResp.SetActive(true);
            }

            yield return new WaitForSeconds(5);

            Application.LoadLevel("Title_Scene");
            yield break;

        }
        

    }
    public void selecionarResposta(int botao)
    {
        StartCoroutine(selecionarRespostaAcao(botao));
    }


}
