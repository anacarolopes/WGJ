using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimatedObject : MonoBehaviour
{
    
    public bool isActive; //mostra se o objeto está ativo na cena
    Animator animControler; //componente de animação
    public GameObject fadeParent; //objeto Pai que possui os elementos do cenário
    FadeObject[] fadeObjects; //objetos da cena que farão o fade
    public float animationDuration; //duração da animação
    void Awake() {
        animControler = GetComponent<Animator>(); //procura o componente de animação no objeto com este script
    }

    public void Start() {
        StartCoroutine(TimePass()); //inicia a corrotina de troca de dia e noite
        fadeObjects = fadeParent.GetComponentsInChildren<FadeObject>();
    }

    //corrotina que faz a troca do dia e da noite
    public IEnumerator TimePass() {
        Fade(); //move o objeto para passar pela cena
        yield return new WaitForEndOfFrame(); //espera o final do frame para receber a duração da animação
        yield return new WaitForSeconds(animationDuration); //espera a duração da animação para continuar
        FadeScene(); //deixa o cenário invisivel
        yield return new WaitForSeconds(2); //espera 2 segundos
        Fade(); //move o objeto de volta a posição inicial
        yield return new WaitForSeconds(animationDuration); //espera a duração da animação para continuar
        FadeScene(); //deixa o cenário visivel novamente
        yield return new WaitForSeconds(2); //espera 2 segundos
        StartCoroutine(TimePass()); //reinicia a corrotina
    }

    //verifica se o objeto deve receber um fade in ou um fade out e inverte os isActive
    public void Fade() {
        animControler.SetTrigger(isActive ? "FadeOut" : "FadeIn"); // verifica se IsActive está true, se estiver, fade in, se não, fade out
        isActive = !isActive; //inverte o estado do objeto, se está true fica false, se false fica true
        animationDuration = animControler.GetCurrentAnimatorClipInfo(0)[0].clip.length; //passa ai dayDuration a curação da animação atual
    }

    //Procura cada objeto do background e chama a sua função de fade
    public void FadeScene() {
        foreach (FadeObject o in fadeObjects)
            o.Fade(); //para cada objeto em fadeObjects, executa o seu fade
    }
}
