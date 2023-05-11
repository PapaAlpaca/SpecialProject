using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;
    [SerializeField] private SoundHandler sfx;
    private float[] floors = {1f, 15f};
    private int currFloor = 1;
    private bool doorsOpening = false;
    private bool moving = false;
    private bool reachedFloor = true;

    void Update() {
        if(moving) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                new Vector3(transform.localPosition.x, floors[currFloor], transform.localPosition.z), 2*Time.deltaTime);
        }
        if(doorsOpening) {
            leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition,
                new Vector3(1.2f, leftDoor.localPosition.y, leftDoor.localPosition.z), Time.deltaTime);
            rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition,
                new Vector3(-1.2f, rightDoor.localPosition.y, rightDoor.localPosition.z), Time.deltaTime);
        } else {
            leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition,
                new Vector3(0.4f, leftDoor.localPosition.y, leftDoor.localPosition.z), Time.deltaTime);
            rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition,
                new Vector3(-0.4f, rightDoor.localPosition.y, rightDoor.localPosition.z), Time.deltaTime);
        }
    }

    void LateUpdate() {
        if(!reachedFloor && moving && transform.localPosition.y == floors[currFloor]) {
            sfx.play(SoundHandler.MAIN);
            reachedFloor = true;
            moving = false;
            doorsOpening = true;
        }
    }

    public void move(int floor) {
        sfx.play(SoundHandler.ELEVATOR);
        moving = true;
        reachedFloor = false;
        currFloor = (floor < 0)? 0: (floor > floors.Length-1)? floors.Length-1: floor;
    }
    public int getFloor() { return currFloor; }
    public void openDoors() { doorsOpening = true; }
    public void closeDoors() { doorsOpening = false; }
    public void toggleDoors() { doorsOpening = !doorsOpening; }
}