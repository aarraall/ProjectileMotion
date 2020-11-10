using UnityEngine;

namespace Controllers
{
    public enum ObjectType
    {
        ARTILLERY,
        AIM
    }

    public class ObjectController : MonoBehaviour
    {
        private float objectSpeed = 10f;
        //public bool isMoving = true;
        public ObjectType _objectType;
        public Transform artillery;
        public Transform aim;

        private int clickCounter;
        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _objectType = ObjectType.AIM;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _objectType = ObjectType.ARTILLERY;
            }

            if (_objectType == ObjectType.AIM)
            {
                Move(aim);
            }
            else if (_objectType == ObjectType.ARTILLERY)
            {
                Move(artillery);
            }
        }

        void Move(Transform _object)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Field")) //&& isMoving)
                {
                    _object.position = Vector3.Lerp(_object.position, hit.point + new Vector3(0, .5f, 0),
                        objectSpeed * Time.deltaTime);
            
                    if (Input.GetMouseButtonDown(0))
                    {
                        _object.position = hit.point + new Vector3(0, .5f, 0);
                        //isMoving = !isMoving;
                    }
                }
            }
        }
    }
}