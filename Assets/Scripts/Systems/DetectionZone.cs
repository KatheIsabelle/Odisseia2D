using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DetectionZone : MonoBehaviour
{
    public string tagTarget = "Player";
    public List<Collider2D> detectedObjs = new List<Collider2D>();
    private bool animationComplete = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(tagTarget))
        {
            detectedObjs.Add(collider);
            if (animationComplete)
            {
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(tagTarget))
        {
            detectedObjs.Remove(collider);
            GetComponent<Collider2D>().enabled = true;
        }
    }

    //  animação estiver completa
    public void AnimationComplete()
    {
        animationComplete = true;
        // Desativa o collider se houver jogadores detectados
        if (detectedObjs.Count > 0)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
}