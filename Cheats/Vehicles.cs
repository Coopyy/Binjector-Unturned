using Binjector.Utilities;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Binjector.Cheats
{
    public class Vehicles : MonoBehaviour
    {
        public static EEngine CarEngine;
        private InteractableVehicle car;
        void Update()
        {
            car = Player.player.movement.getVehicle();
            if (MenuGUI.instance.customengine)
            {
                if (CarEngine == EEngine.CAR)
                {
                    Functions.ChangeEngine(car, EEngine.CAR);
                    car.GetComponent<Rigidbody>().useGravity = true;
                }
                else if (CarEngine == EEngine.BOAT)
                {
                    Functions.ChangeEngine(car, EEngine.BOAT);
                    car.GetComponent<Rigidbody>().useGravity = true;
                }
                else if (CarEngine == EEngine.HELICOPTER)
                {
                    Functions.ChangeEngine(car, EEngine.HELICOPTER);
                    car.GetComponent<Rigidbody>().useGravity = false;
                }
                else if (CarEngine == EEngine.PLANE)
                {
                    Functions.ChangeEngine(car, EEngine.PLANE);
                    car.GetComponent<Rigidbody>().useGravity = false;
                }
                else if (CarEngine == EEngine.BLIMP)
                {
                    Functions.ChangeEngine(car, EEngine.BLIMP);
                    car.GetComponent<Rigidbody>().useGravity = false;
                }
            }

            if (MenuGUI.instance.noclip)
            {
                car = Player.player.movement.getVehicle();
                if (car == null) return;
                
                Rigidbody component = car.GetComponent<Rigidbody>();
                component.useGravity = false;
                component.isKinematic = true;
                Transform transform = car.transform;

                if (Input.GetKey(KeyCode.W))
                {
                    component.MovePosition(transform.position + transform.forward / 6f * MenuGUI.instance.speedMultiplier);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    component.MovePosition(transform.position - transform.forward / 5f * MenuGUI.instance.speedMultiplier);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(0f, -0.6f, 0f);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(0f, 0.6f, 0f);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Rotate(-0.8f, 0f, 0f);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Rotate(0.8f, 0f, 0f);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Rotate(0f, 0f, 0.8f);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Rotate(0f, 0f, -0.8f);
                }
            }
        }
    }
}
