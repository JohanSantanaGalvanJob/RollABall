using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InitialSpawn : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        var player1 = PlayerInput.Instantiate(prefab, 0, "WASD", 0, Keyboard.current);

        player1.transform.position = new Vector3(-2, 0.5f, 0);

    }

}
