using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public string AssuntoCard;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.name != "Hand")
        {
            GameObject Card = GameObject.Find(eventData.pointerDrag.name);
            var pergunta = Card.GetComponent<CardScr>().pergunta;
            MasterScr.PerguntaAtual = pergunta;
            MasterScr.Pergunta.GetComponent<Text>().text = pergunta.Texto;
            
            MasterScr.RespostaA.GetComponent<Text>().text = pergunta.Respostas[0];
            MasterScr.RespostaB.GetComponent<Text>().text = pergunta.Respostas[1];
            MasterScr.RespostaC.GetComponent<Text>().text = pergunta.Respostas[2];
            MasterScr.RespostaD.GetComponent<Text>().text = pergunta.Respostas[3];
            Card.SetActive(false);
            MasterScr.Panel.SetActive(true);
            MasterScr.Overlay.SetActive(true);


        }
        else
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.parentToReturnTo = this.transform;
            }
        }
    }
}
