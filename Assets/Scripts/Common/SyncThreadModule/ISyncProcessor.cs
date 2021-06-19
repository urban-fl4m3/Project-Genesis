using System.Collections;
using UnityEngine;

namespace Common.SyncThreadModule
{
    public interface ISyncProcessor
    {
        void Create();
        Coroutine StartSyncProcess(IEnumerator process);
        void StopSyncProcess(Coroutine process);
    }
}