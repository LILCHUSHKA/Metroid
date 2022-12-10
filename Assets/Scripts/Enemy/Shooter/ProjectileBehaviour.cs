using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour
{
    private void FixedUpdate() => FlyToPoint();

    public virtual void FlyToPoint()
    {
    }

    protected IEnumerator DestroyTimer(int destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}