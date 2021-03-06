using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extension Method is a method that can be used in a particular data type.
/// </summary>
public static class SystemExtensions{
    public static void Log(this object value){
        #if UNITY_EDITOR
        Debug.Log(value.ToString());
        #endif
    }

    /// <summary>
    /// It automatically stops when you convert the scene.
    /// </summary>
    public static IEnumerator Start(this IEnumerator coroutine, MonoBehaviour behaviour){
        behaviour.StartCoroutine(coroutine);
        return coroutine;
    }

    public static void Stop(this IEnumerator coroutine, MonoBehaviour behaviour){
        behaviour.StopCoroutine(coroutine);
    }

    /// <summary>
    /// If there is no return value, it will be returned after adding it.
    /// </summary>>
    public static T GetComponentSafe<T>(this GameObject gameObject) where T : MonoBehaviour {
        var component = gameObject.GetComponent<T>(); 
        if (component == null) {
            component = gameObject.AddComponent<T>();
        }

        return component;
    }    
    
    public static T GetComponentSafe<T>(this Transform transform) where T : MonoBehaviour {
        var component = transform.GetComponent<T>(); 
        if (component == null) {
            component = transform.gameObject.AddComponent<T>();
        }

        return component;
    }

    public static T GetRandomItem<T>(this List<T> baseList) {
        return baseList[Random.Range(0, baseList.Count)];
    }
    
    public static void Shuffle<T>(this List<T> baseList) {
        var copyList = baseList.ConvertAll((item) => item);
        baseList.Clear();
        
        do {
            var copyItem = copyList.GetRandomItem();
            baseList.Add(copyItem);
            copyList.Remove(copyItem);
        } while (copyList.Count > 0);
    }
}