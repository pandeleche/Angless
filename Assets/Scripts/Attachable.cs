using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Attachable : MonoBehaviour
{

    public int interactiveLayer = 10;
    public Collider myCollider;
    public Hand controllerScript;
    public Transform hand;
    public Vector3 cosa;
    public GameObject sword;
    public GameObject controller;

    private bool attached;
    private GameObject theClosestGO;
    // Use this for initialization
    void Start()
    {
        sword.transform.position = hand.position + cosa;
        sword.transform.rotation = hand.rotation;
        controllerScript.controllerPrefab = sword;

        //        controllerScript.AttachObject(sword);
    }

    // Update is called once per frame
    void Update()
    {
        sword.transform.position = hand.position + cosa;
        sword.transform.rotation = hand.rotation;
    }
    /*	void DoClick()
        {
            if (theClosestGO != null) {
                attached = true;
                controllerScript.AttachObject (sword);
            }
        }
        void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.layer == interactiveLayer)
            {
                theClosestGO = collision.gameObject;
            }
        }
        void OnTriggerExit(Collider collision)
        {
            theClosestGO = null;
        }*/
}