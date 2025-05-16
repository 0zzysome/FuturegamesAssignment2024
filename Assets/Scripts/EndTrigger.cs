using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Debug.Log("YOU WIN!");
        }

    }
}
