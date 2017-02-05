using UnityEngine;
using UnityEngine.SceneManagement;

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
        private AudioSource[] sounds;
        bool Lefttouchingobject;
        bool Righttouchingobject;
        public GameObject numbertouchsphere;
        
        public int pinchCountL;
        private float timeGapL;

        public int pinchCountR;
        private float timeGapR;


        void Start()
        {
            //      if (_pinchDetectorA == null || _pinchDetectorB == null) {
            //        Debug.LogWarning("Both Pinch Detectors of the LeapRTS component must be assigned. This component has been disabled.");
            //        enabled = false;
            //      }
            sounds = gameObject.GetComponents<AudioSource>();
            Lefttouchingobject = false;
            Righttouchingobject = false;
            GameObject pinchControl = new GameObject("RTS Anchor");
            _anchor = pinchControl.transform;
            _anchor.transform.parent = transform.parent;
            transform.parent = _anchor;
            pinchCountL = 0;
           // numbertouchsphere = GameObject.Find("touchsphere");
        }

        public void refresh()
        {
            Lefttouchingobject = false;
            Righttouchingobject = false;
        }

        void Update()
        {
            bool myflag = false;
            if(transform.childCount == 2)
            {
                fbleftdebug = transform.GetChild(1).GetComponent<touchFB>().lefttouch;
                fbrightdebug = transform.GetChild(1).GetComponent<touchFB>().righttouch;
            }else
            {
                fbleftdebug = transform.GetChild(0).GetComponent<touchFB>().lefttouch;
                fbrightdebug = transform.GetChild(0).GetComponent<touchFB>().righttouch;
            }
            


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
                    sounds[0].Play();

                    if(transform.GetChild(0).GetComponent<CubeProperty>().cubeType == "subtraction")
                    {
                        //double click detect
                        if (pinchCountL == 1)// avoid redundant
                        {
                            if (Time.time - timeGapL > 1)// not validate click
                            {
                                pinchCountL = 0;
                            }

                        }
                        if (pinchCountL == 0)
                        {
                            timeGapL = Time.time;
                        }
                        if (pinchCountL == 1)
                        {
                            timeGapL = Time.time - timeGapL;
                            if (timeGapL <= 1)
                            {
                                Debug.Log("Left double click success!");
                                enlargeCube();
                            }
                        }
                        pinchCountL++;
                        if (pinchCountL == 2)
                        {
                            pinchCountL = 0;
                        }
                    }
                    
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
                            sounds[0].Play();

                    if (transform.GetChild(0).GetComponent<CubeProperty>().cubeType == "subtraction")
                    {
                        //double click detect Right
                        if (pinchCountR == 1)// avoid redundant
                        {
                            if (Time.time - timeGapR > 1)// not validate click
                            {
                                pinchCountR = 0;
                            }

                        }
                        if (pinchCountR == 0)
                        {
                            timeGapR = Time.time;
                        }
                        if (pinchCountR == 1)
                        {
                            timeGapR = Time.time - timeGapR;
                            if (timeGapR <= 1)
                            {
                                Debug.Log("Right double click success!");
                                enlargeCube();
                            }
                        }
                        pinchCountR++;
                        if (pinchCountR == 2)
                        {
                            pinchCountR = 0;
                        }

                    }
                       
                    Righttouchingobject = true;
                          
                            myflag = true;  
                        }
                

                   }
                    else {
                    Righttouchingobject = false;
     
                 }

                if (Righttouchingobject || Lefttouchingobject)
                {
                // first judge if it is coloned cube
                //numbertouchsphere.SetActive(true);
                    if (transform.childCount == 2){
                        transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
                    } else {
                        numbertouchsphere.SetActive(true);
                    }
                } else {
                    if (transform.childCount == 2){
                        transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
                    }else{
                        numbertouchsphere.SetActive(false);
                    }
                //numbertouchsphere.SetActive(false); 

                }


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
                if(GUILayout.Button("reset the scene"))
                {
                    touchFB.createTag = false;//set static to default
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    
                }
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

        private void enlargeCube()
        {
            Vector3 size = transform.GetChild(0).transform.localScale;
            if (!transform.GetChild(0).GetComponent<touchFB>().large)
            {
                transform.GetChild(0).transform.localScale = new Vector3(size.x * 2, size.y * 2, size.z * 2);
                transform.GetChild(0).GetComponent<touchFB>().large = true;
            }
        }
    }

}




