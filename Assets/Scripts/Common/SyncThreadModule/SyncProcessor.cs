using System.Collections;
using UnityEngine;

namespace Common.SyncThreadModule
{
    public class SyncProcessor : ISyncProcessor
    {
        private SyncObject _object;

        public void Create()
        {
            if (_object != null)
            {
                return;
            }
            
            _object = new GameObject(nameof(SyncProcessor)).AddComponent<SyncObject>();
            Object.DontDestroyOnLoad(_object);
        }

        public Coroutine StartSyncProcess(IEnumerator process)
        {
            return _object.StartCoroutine(process);
        }

        public void StopSyncProcess(Coroutine process)
        {
            _object.StopCoroutine(process);
        }
    }
}