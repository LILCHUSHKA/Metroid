using UnityEngine;

//Пересмотреть
public class PunchBouncePattern : BouncePattern
{
    //Запустить анимацию атаки и после завершения анимации включить isRetreat у НПС. Процесс отпрыгивания запустится сам
    void Punch() =>
        anim.Play("Punch");

    //Тестовый метод. В нем будет описываться TakeDamage() по персонажу. Почему не использовать GiveDamage() - не помню
    public void Attack() =>
        Debug.Log("Give damage");

    public override void ActivePattern() => Punch();
}