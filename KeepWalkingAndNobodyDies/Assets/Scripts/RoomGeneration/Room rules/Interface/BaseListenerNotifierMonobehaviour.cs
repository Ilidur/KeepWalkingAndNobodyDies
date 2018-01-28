using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseListenerNotifierMonoBehaviour<Interface> : MonoBehaviour
    {
        protected List<Interface> listeners;

        public void RegisterListener(Interface listener)
        {
            if (listeners == null)
            {
                listeners = new List<Interface>();
            }
            if(!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void DeregisterListener(Interface listener)
        {
            if (listeners == null)
            {
                listeners = new List<Interface>();
            }
            if(listeners.Contains(listener))
                listeners.Remove(listener);
        }


        protected abstract void NotifyListeners(int notification);

    }