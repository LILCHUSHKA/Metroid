using UnityEngine;

//Ошибки указаны в PunchBouncePattern
public class PunchPattern : RunAwayPattern
{
    void Punch() =>
        anim.Play("Punch");

    public void Attack() =>
        Debug.Log("Give damage");

    public override void ActivePattern() => Punch();
}