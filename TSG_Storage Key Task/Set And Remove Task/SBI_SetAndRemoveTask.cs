using System;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Добавляет и удаляет Task из указанного хранилеща
/// </summary>
public class SBI_SetAndRemoveTask : MonoBehaviour
{
    [SerializeField]
    private GetDKOPatch _patchStorageTask;
    
    [SerializeField] 
    private GetDataSO_TSG_KeyStorageTask _keyStorageTask;
    [SerializeField] 
    private GetDataSO_TSG_KeyTaskData _keyTask;
    
    [SerializeField] 
    private string _textBlock;

    [SerializeField] 
    private bool _removeTaskBlockOnDestroy = true;

    private TSG_StorageKeyTaskDataMono _storageKeyTask;
    
    private bool _isInit = false;
    public bool IsInit => _isInit;
    public event Action OnInit;
    
    private void Awake()
    {
        if (_patchStorageTask.Init == false)
        {
            _patchStorageTask.OnInit += OnInitStoragePanel;
            return;
        }

        GetDataDKO();
    }

    private void OnInitStoragePanel()
    {
        _patchStorageTask.OnInit -= OnInitStoragePanel;
        GetDataDKO();
    }

    private void GetDataDKO()
    {
        var DKOData = (DKODataInfoT<TSG_StorageKeyTaskDataMono>)_patchStorageTask.GetDKO();
        _storageKeyTask = DKOData.Data; 
        
        _isInit = true;
        OnInit?.Invoke();
    }

    public void SetTaskBlockOpen()
    {
        if (_storageKeyTask.GetTaskData(_keyStorageTask.GetData()).IsKeyTask(_keyTask.GetData()) == false)
        {
            _storageKeyTask.GetTaskData(_keyStorageTask.GetData()).AddTask(_keyTask.GetData(), _textBlock);
        }
    }

    public void RemoveTaskBlockOpen()
    {
        if (_storageKeyTask.GetTaskData(_keyStorageTask.GetData()).IsKeyTask(_keyTask.GetData()) == true)
        {
            _storageKeyTask.GetTaskData(_keyStorageTask.GetData()).RemoveTask(_keyTask.GetData());
        }
    }

    private void OnDestroy()
    {
        if (_removeTaskBlockOnDestroy == true)
        {
            RemoveTaskBlockOpen();
        }
    }
}
