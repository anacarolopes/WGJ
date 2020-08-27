using UnityEngine;
using UnityEngine.UI;

public class FadeObject : MonoBehaviour
{
    public bool isActive; //mostra se está ativo na cena
    Animator animControler; //objeto que possui a animação

    void Awake() {
        animControler = GetComponent<Animator>(); //procura o componente de animação no objeto com este script
    }

    //verifica se o objeto deve receber um fade in ou um fade out e inverte os isActive
    public void Fade() {
        animControler.SetTrigger(isActive ? "FadeOut" : "FadeIn"); // verifica se IsActive está true, se estiver, fade in, se não, fade out
        isActive = !isActive;
    }
}