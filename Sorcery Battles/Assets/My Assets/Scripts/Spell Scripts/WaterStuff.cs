﻿using UnityEngine;

public class WaterStuff : MonoBehaviour {
    public float UvRotateSpeed = 1;
    public float UvRotateDistance = 1;
    public float UvBumpRotateSpeed = 1;
    public float UvBumpRotateDistance = 1;
    
    float timeTime;
    Vector2 Vector2one, lwVector, lwNVector, ssgVector;
    Vector3 Vector3forward;

    private void Awake() {
        lwVector = Vector2.zero;
        lwNVector = Vector2.zero;
        ssgVector = Vector2.zero;
    }    
    void Update() {
        if (timeTime != Time.time) timeTime = Time.time;
        if (Vector3forward != Vector3.forward) Vector3forward = Vector3.forward;
        if (Vector2one != Vector2.one) Vector2one = Vector2.one;        

        lwVector = Quaternion.AngleAxis(timeTime * UvRotateSpeed, Vector3forward) * Vector2one * UvRotateDistance;
        lwNVector = Quaternion.AngleAxis(timeTime * UvBumpRotateSpeed, Vector3forward) * Vector2one * UvBumpRotateDistance;

        Shader.SetGlobalFloat("_WaterLocalUvX", lwVector.x);
        Shader.SetGlobalFloat("_WaterLocalUvZ", lwVector.y);
        Shader.SetGlobalFloat("_WaterLocalUvNX", lwNVector.x);
        Shader.SetGlobalFloat("_WaterLocalUvNZ", lwNVector.y);
    }
}
