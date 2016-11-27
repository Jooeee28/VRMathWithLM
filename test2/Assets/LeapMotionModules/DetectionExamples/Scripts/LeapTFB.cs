using UnityEngine;
namespace Leap.Unity
{


    public class LeapTFB : MonoBehaviour
    {
        public bool fbleftdebug;
        public bool fbrightdebug;
        public enum RotationMethod
        {
            None,
            Single,
            Full
        }

        [SerializeField]
        private PinchDetector _pinchDetectorA;
        public PinchDetector PinchDetectorA
        {
            get
            {
                return _pinchDetectorA;
            }
            set
            {
                _pinchDetectorA = value;
            }
        }


        [SerializeField]
        private PinchDetector _pinchDetectorB;
        public PinchDetector PinchDetectorB
        {
            get
            {
                return _pinchDetectorB;
            }
            set
            {
                _pinchDetectorB = value;
            }
        }

        [SerializeField]
        private RotationMethod _oneHandedRotationMethod;

        [SerializeField]
        private RotationMethod _twoHandedRotationMethod;

        [SerializeField]
        private bool _allowScale = true;

        [Header("GUI Options")]
        [SerializeField]
        private KeyCode _toggleGuiState = KeyCode.None;

        [SerializeField]
        private bool _showGUI = true;

        private Transform _anchor;

        private float _defaultNearClip;
        private AudioSource ascomp;
        bool Lefttouchingobject;
        bool Righttouchingobject;
        public GameObject numbertouchsphere;
        void Start()
        {
            //      if (_pinchDetectorA == null || _pinchDetectorB == null) {
            //        Debug.LogWarning("Both Pinch Detectors of the LeapRTS component must be assigned. This component has been disabled.");
            //        enabled = false;
            //      }
            ascomp = gameObject.GetComponent<AudioSource>();
            Lefttouchingobject = false;
            Righttouchingobject = false;
            GameObject pinchControl = new GameObject("RTS Anchor");
            _anchor = pinchControl.transform;
            _anchor.transform.parent = transform.parent;
            transform.parent = _anchor;
           // numbertouchsphere = GameObject.Find("touchsphere");
        }

        void Update()
        {
            bool myflag = false;
            fbleftdebug = transform.GetChild(0).GetComponent<touchFB>().lefttouch;
            fbrightdebug = transform.GetChild(0).GetComponent<touchFB>().righttouch;


                if (Input.GetKeyDown(_toggleGuiState))
                {
                    _showGUI = !_showGUI;
                }

                bool didUpdate = false;
                if (_pinchDetectorA != null)
                    didUpdate |= _pinchDetectorA.DidChangeFromLastFrame;
                if (_pinchDetectorB != null)
                    didUpdate |= _pinchDetectorB.DidChangeFromLastFrame;

                if (didUpdate)
                {
                    transform.SetParent(null, true);
                }




            /* if (_pinchDetectorA != null && _pinchDetectorA.IsPinching &&
                   _pinchDetectorB != null && _pinchDetectorB.IsPinching)
              {
                 //  transformDoubleAnchor();
               }*/

               if (_pinchDetectorA != null && _pinchDetectorA.IsPinching && fbleftdebug)
                {
                    // transformSingleAnchor(_pinchDetectorA);
                    _anchor.position = _pinchDetectorA.Position;
                    if (!Lefttouchingobject) {
                        ascomp.Play();
                        Lefttouchingobject = true;
                      
                        myflag = true;
                    }

                 }
                else {
                    Lefttouchingobject = false;
                  
                }
                if (_pinchDetectorB != null && _pinchDetectorB.IsPinching && fbrightdebug)
                    {
                        //transformSingleAnchor(_pinchDetectorB);
                        _anchor.position = _pinchDetectorB.Position;
                        if (!Righttouchingobject)
                        {
                            ascomp.Play();
                            Righttouchingobject = true;
                          
                            myflag = true;  
                        }
                

                   }
                    else {
                    Righttouchingobject = false;
     
                 }

                if (Righttouchingobject || Lefttouchingobject)
                {
                    numbertouchsphere.SetActive(true);
                }else { numbertouchsphere.SetActive(false); }


                if (didUpdate)
                {
                    transform.SetParent(_anchor, true);
                }
            
        }

        void OnGUI()
        {
            if (_showGUI)
            {
                GUILayout.Label("One Handed Settings");
                doRotationMethodGUI(ref _oneHandedRotationMethod);
                GUILayout.Label("Two Handed Settings");
                doRotationMethodGUI(ref _twoHandedRotationMethod);
                _allowScale = GUILayout.Toggle(_allowScale, "Allow Two Handed Scale");
            }
        }

        private void doRotationMethodGUI(ref RotationMethod rotationMethod)
        {
            GUILayout.BeginHorizontal();

            GUI.color = rotationMethod == RotationMethod.None ? Color.green : Color.white;
            if (GUILayout.Button("No Rotation"))
            {
                rotationMethod = RotationMethod.None;
            }

            GUI.color = rotationMethod == RotationMethod.Single ? Color.green : Color.white;
            if (GUILayout.Button("Single Axis"))
            {
                rotationMethod = RotationMethod.Single;
            }

            GUI.color = rotationMethod == RotationMethod.Full ? Color.green : Color.white;
            if (GUILayout.Button("Full Rotation"))
            {
                rotationMethod = RotationMethod.Full;
            }

            GUI.color = Color.white;

            GUILayout.EndHorizontal();
        }

        private void transformDoubleAnchor()
        {
            _anchor.position = (_pinchDetectorA.Position + _pinchDetectorB.Position) / 2.0f;

            switch (_twoHandedRotationMethod)
            {
                case RotationMethod.None:
                    break;
                case RotationMethod.Single:
                    Vector3 p = _pinchDetectorA.Position;
                    p.y = _anchor.position.y;
                    _anchor.LookAt(p);
                    break;
                case RotationMethod.Full:
                    Quaternion pp = Quaternion.Lerp(_pinchDetectorA.Rotation, _pinchDetectorB.Rotation, 0.5f);
                    Vector3 u = pp * Vector3.up;
                    _anchor.LookAt(_pinchDetectorA.Position, u);
                    break;
            }

            if (_allowScale)
            {
                _anchor.localScale = Vector3.one * Vector3.Distance(_pinchDetectorA.Position, _pinchDetectorB.Position);
            }
        }

        private void transformSingleAnchor(PinchDetector singlePinch)
        {
            _anchor.position = singlePinch.Position;

            switch (_oneHandedRotationMethod)
            {
                case RotationMethod.None:
                    break;
                case RotationMethod.Single:
                    Vector3 p = singlePinch.Rotation * Vector3.right;
                    p.y = _anchor.position.y;
                    _anchor.LookAt(p);
                    break;
                case RotationMethod.Full:
                    _anchor.rotation = singlePinch.Rotation;
                    break;
            }

            _anchor.localScale = Vector3.one;
        }
    }

}




