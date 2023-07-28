using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeZombie : ZombieMovement
{
    float meleeRange = 1;

    protected override void ZombieMove(Vector2 findPlayer)
    {
        Vector3 distance = player.transform.position - transform.position;
        if (distance.magnitude >= meleeRange)
        {
            rb.MovePosition((Vector2)transform.position + (findPlayer * speed * Time.deltaTime));
        }
        else rb.MovePosition((Vector2)transform.position + (findPlayer * 0 * Time.deltaTime));
    }
}
