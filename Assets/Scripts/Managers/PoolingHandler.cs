using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Managers
{
    public class PoolingHandler : MonoBehaviour
    {
        [SerializeField] Ball ballPrefab;
        [SerializeField] int startBalls = 16;
        [SerializeField] int endBalls = 24;
        [SerializeField] int activeNumber;
        private readonly Queue<Ball> _ballQueue = new Queue<Ball>();


        private void Start()
        {
            while (_ballQueue.Count < startBalls)
                GenerateBall();
        }

        private void GenerateBall()
        {
            Ball newBall = Instantiate(ballPrefab, transform, true);
            newBall.gameObject.SetActive(false);
            _ballQueue.Enqueue(newBall);
        }

        public Ball TakeBall()
        {
            if (CountActive() > startBalls && CountActive() < endBalls)
                GenerateBall();
            
            Ball takenBall = _ballQueue.Dequeue();
            _ballQueue.Enqueue(takenBall);
            return takenBall;
        }

        private int CountActive()
        {
            for (int i = 0; i < _ballQueue.Count; i++)
            {
                if (_ballQueue.ToList()[i].gameObject.activeInHierarchy == true)
                {
                    activeNumber++;
                }
            }

            return activeNumber;
        }

        // void LookForActiveBalls()
        // {
        //     foreach (var ball in transform.GetComponentsInChildren<Transform>())
        //     {
        //         if (ball.gameObject.activeSelf == true)
        //         {
        //             activeNumber++;
        //             if(activeNumber > startBalls && activeNumber < endBalls)
        //                 GenerateBall();
        //         }
        //     }
        // }
    }
}