using Mechadroids;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Trigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Entrypoint entrypoint;
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            entrypoint.SetUpAIEntities();
        }

    }
}
