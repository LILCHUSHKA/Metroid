using UnityEngine;

//Пересмотреть
public class BouncePattern : RetreatPatterns
{
    [SerializeField] FallingType fall;

    [SerializeField] AnimationCurve bounceDirectionX, bounceDirectionY;

    [SerializeField] float shootMoment;
    float currentTime, totalTime, farmerShootMoment;

    Vector3 pos;

    private void FixedUpdate()
    {
        if (walk.isRetreat == true) BounceOff();
    }

    public override void ActivePattern() => BounceTime();

    protected void BounceTime()
    {
        farmerShootMoment = shootMoment;

        walk.isRetreat = true;
        totalTime = bounceDirectionX.keys[bounceDirectionX.keys.Length - 1].time;
    }

    protected void BounceOff()
    {
        pos = transform.localPosition;
        pos.y += bounceDirectionY.Evaluate(currentTime);

        if (transform.rotation.y == 0)
            pos.x -= bounceDirectionX.Evaluate(currentTime);
        else pos.x += bounceDirectionX.Evaluate(currentTime);

        transform.localPosition = pos;

        currentTime += Time.deltaTime;

        if (currentTime >= shootMoment)
        {
            shootMoment = totalTime + 1;
            ShootInAir();
        }

        if (currentTime >= totalTime)
        {
            shootMoment = farmerShootMoment;
            walk.isRetreat = false;
            currentTime = 0;
        }
    }

    //Если снаряд проваливается под землю - walk.player.transform.position.x + n;
    void ShootInAir()
    {
        fall.endPos.y = walk.player.transform.position.y - 2;

        if (transform.rotation.y == 180)
            fall.endPos.x = walk.player.transform.position.x;
        else
            fall.endPos.x = walk.player.transform.position.x;

        Instantiate(fall, new Vector3(walk.parent.position.x, walk.parent.position.y, 0), transform.rotation);
    }
}