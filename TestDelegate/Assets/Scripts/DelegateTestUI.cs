using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTestUI : MonoBehaviour
{
	public static string[] CITYLIST = { "서울", "전주", "부산" };

	[SerializeField] TextItem[] m_TextItems = null;
	[SerializeField] Text m_txtResult = null;

	[SerializeField] Button m_btnResult = null;
	[SerializeField] Button m_btnClear = null;

	int m_nSelectIndex = 1;

	void Start()
    {
		m_btnResult.onClick.AddListener(OnClick_Result);
		m_btnClear.onClick.AddListener(OnClick_Clear);

		Initialize();
    }

	public void Initialize()
	{
		for(int i = 0; i < m_TextItems.Length; i++)
		{
			m_TextItems[i].OnAddListner(OnCallback_TextItem);
			m_TextItems[i].Initialize(i, CITYLIST[i]);
		}
	}
	
	public void Initialize2()
	{
		for(int i = 0; i < m_TextItems.Length; i++)
		{
			m_TextItems[i].OnAddListner((TextItem kItem, bool bSelect) =>
			{
				OnCallback_TextItem(kItem, bSelect);
			});
		}
	}

	public void OnCallback_TextItem(TextItem kItem, bool bSelect)
	{
		ClearAllSelectItem();
		kItem.SetSelectedColor(bSelect);
		m_nSelectIndex = kItem.m_Index;

		PrintResult(m_nSelectIndex);
	}

	void ClearAllSelectItem()
	{
		for(int i=0; i<m_TextItems.Length; i++)
		{
			m_TextItems[i].ClearSelect();
		}
	}

	public void PrintResult(int nSelectIdx)
	{
		string sName = CITYLIST[nSelectIdx];
		m_txtResult.text = sName;
	}

	public void OnClick_Result()
	{
		string sName = CITYLIST[m_nSelectIndex];
		m_txtResult.text = string.Format("선택된 도시는 {0} 입니다.", sName);
	}

	public void OnClick_Clear()
	{
		m_txtResult.text = "";
		ClearAllSelectItem();
		m_nSelectIndex = -1;
	}
}
