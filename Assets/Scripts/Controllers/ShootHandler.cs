using System.Collections;
using Controllers;
using Managers;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    private PoolingHandler _poolingHandler;
    [SerializeField] private Transform _aimPos;
    [SerializeField] private Transform _artilleryPos;
    [SerializeField] private Transform _artilleryPivot;

    // float bounceSpeed = 100f;
    // float bounceAmount = 100f;

    [Tooltip("Changing firing angle effects the reach time and angle of ball to the target")]
    public float firingAngle = 45f;

    [Tooltip("Changing gravity effects the speed of ball")]
    public float gravity = 9.8f;
    

    private void Start()
    {
        _poolingHandler = FindObjectOfType<PoolingHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //_objectController.isMoving = false;
            _artilleryPivot.LookAt(_aimPos);
            Ball ball = _poolingHandler.TakeBall();
            //StartCoroutine(ProjectileMotion(ball));
            ball.ProjectileMotion(_artilleryPos, _aimPos, firingAngle, gravity);
        }
    }

    // IEnumerator ProjectileMotion(GameObject ball)
    // {
    //     // Short delay added before Projectile is thrown
    //     yield return new WaitForSeconds(0.2f);
    //     // Move projectile to the position of throwing object + add some offset if needed.
    //     ball.transform.position = _artilleryPos.position + new Vector3(0, 0.0f, 0);
    //     ball.SetActive(true);
    //     
    //     // Calculate distance to target
    //     Vector3 ballTransformPosition = ball.transform.position;
    //     float targetDistance = Vector3.Distance(ballTransformPosition, _aimPos.transform.position);
    //
    //     // Calculate the velocity needed to throw the object to the target at specified angle.
    //     float projectileVelocity = targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
    //
    //     // Horizontal motion velocity calculation
    //     float Vx = Mathf.Sqrt(projectileVelocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
    //     // Vertical motion velocity calculation
    //     float Vy = Mathf.Sqrt(projectileVelocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
    //
    //     // Calculate flight time
    //     float flightDuration = targetDistance / Vx;
    //
    //     // Rotate projectile to face the target
    //     ball.transform.rotation = Quaternion.LookRotation(_aimPos.transform.position - ballTransformPosition);
    //
    //     float elapseTime = 0;
    //
    //     while (elapseTime < flightDuration)
    //     {
    //         ball.transform.Translate(0, (Vy - (gravity * elapseTime)) * Time.deltaTime, Vx * Time.deltaTime);
    //
    //         elapseTime += Time.deltaTime;
    //         
    //
    //         yield return null;
    //     }
    //
    //     // while (Vector3.Distance(ballTransformPosition, _aimPos.transform.position) > 0.001)
    //     // {
    //     //     //ballTransformPosition.y = Bounce((Time.time * bounceSpeed)%1) * bounceAmount;
    //     //     ballTransformPosition = Vector3.MoveTowards(ballTransformPosition, _aimPos.transform.position, 0.01f);
    //     //     yield return new WaitForSecondsRealtime(3);
    //     // }
    //
    //     ball.gameObject.SetActive(false);
    //     yield return new WaitForSeconds(1.5f);
    //     //_objectController.isMoving = true;
    // }
}