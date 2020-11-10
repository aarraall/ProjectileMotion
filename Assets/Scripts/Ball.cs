using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using UnityEngine;


public class Ball : MonoBehaviour
{
    private bool _canMove;
    private float _targetDistance;
    private float _projectileVelocity;
    private float _vx;
    private float _vy;
    private float _flightDuration;
    private float _gravity;
    private float _elapseTime;

    private void FixedUpdate()
    {
        if (_canMove)
        {
            if (_elapseTime < _flightDuration)
            {
                transform.Translate(0, (_vy - (_gravity * _elapseTime)) * Time.deltaTime, _vx * Time.deltaTime);
                _elapseTime += Time.deltaTime;
                //yield return null
            }
            else
            {
                _canMove = false;
                _elapseTime = 0;
            }
        }
    }

    public void ProjectileMotion(Transform _artilleryPos, Transform _aimPos, float firingAngle, float gravity)
    {
        this._gravity = gravity;
        // Move projectile to the position of throwing object + add some offset if needed.
        transform.position = _artilleryPos.position + new Vector3(0, 0.0f, 0);
        gameObject.SetActive(true);
        // Calculate distance to target
        Vector3 ballTransformPosition = transform.position;
        _targetDistance = Vector3.Distance(ballTransformPosition, _aimPos.transform.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        _projectileVelocity = _targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Horizontal motion velocity calculation
        _vx = Mathf.Sqrt(_projectileVelocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        // Vertical motion velocity calculation
        _vy = Mathf.Sqrt(_projectileVelocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time
        _flightDuration = _targetDistance / _vx;

        // Rotate projectile to face the target
        transform.rotation = Quaternion.LookRotation(_aimPos.transform.position - ballTransformPosition);
        _canMove = true;

        // while (elapseTime < flightDuration)
        // {
        //     transform.Translate(0, (Vy - (gravity * elapseTime)) * Time.deltaTime, Vx * Time.deltaTime);
        //     elapseTime += Time.deltaTime;
        //     //yield return null
        // }

        // while (Vector3.Distance(ballTransformPosition, _aimPos.transform.position) > 0.001)
        // {
        //     //ballTransformPosition.y = Bounce((Time.time * bounceSpeed)%1) * bounceAmount;
        //     ballTransformPosition = Vector3.MoveTowards(ballTransformPosition, _aimPos.transform.position, 0.01f);
        //     yield return new WaitForSecondsRealtime(3);
        // 
        //gameObject.SetActive(false);
        //_objectController.isMoving = true;
    }
}