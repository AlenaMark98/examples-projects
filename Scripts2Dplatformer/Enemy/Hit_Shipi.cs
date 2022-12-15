using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Shipi : MonoBehaviour
{
    [SerializeField] private Collider2D Hit_DisableCollider; //  Коллайдер для урона

    public void No_Hit()
    {
        //  Отключить коллайдер
        if (Hit_DisableCollider != null)
            Hit_DisableCollider.enabled = false;
    }

    public void Hit()
    {
        //   Включить коллайдер
        if (Hit_DisableCollider != null)
            Hit_DisableCollider.enabled = true;
    }
}
