using UnityEngine; 
using TListPlugin; 
[System.Serializable]
public class IdentifierAndData_TSG_KeyStorageTask : AbsIdentifierAndData<IndifNameSO_TSG_KeyStorageTask, string, TSG_KeyStorageTask>
{

 [SerializeField] 
 private TSG_KeyStorageTask _dataKey;


 public override TSG_KeyStorageTask GetKey()
 {
  return _dataKey;
 }
}
