using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void OnClick()
    {
        particleSystem.Play();
        // Add your logic to start the game here
    }
}
