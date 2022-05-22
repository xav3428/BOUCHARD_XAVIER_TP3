using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            shootInput?.Invoke();
        if (Input.GetButtonDown("Reload"))
            reloadInput?.Invoke();
    }
}
