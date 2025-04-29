using UnityEngine; 
using TListPlugin; 
[System.Serializable]
public class IdentifierAndData_TSG_KeyTaskData : AbsIdentifierAndData<IndifNameSO_TSG_KeyTaskData, string, TSG_KeyTaskData>
{

 [SerializeField] 
 private TSG_KeyTaskData _dataKey;


 public override TSG_KeyTaskData GetKey()
 {
  return _dataKey;
 }
}
