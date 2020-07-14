using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextItem : MonoBehaviour
{
	public delegate void DelegateFunc(TextItem kItem, bool bSelect);
	public DelegateFunc OnSelectedFunc = null;

	[SerializeField] Text m_txtName = null;
 
	Button m_btnSelect = null;
	Color m_OriColor = Color.white;

	public int m_Index = 0;

    void Start()
    {
		m_OriColor = GetComponent<Image>().color;

		m_btnSelect = GetComponent<Button>();
		m_btnSelect.onClick.AddListener(OnClick_Select);
    }

	public void Initialize(int idx, string sName)
	{
		m_Index = idx;
		m_txtName.text = sName;
	}

	public void OnAddListner(DelegateFunc func)
	{
		OnSelectedFunc = new DelegateFunc(func);
	}

	public void OnClick_Select()
	{
		if (OnSelectedFunc != null)
		{
			OnSelectedFunc(this, true);
			Debug.Log("dd");
		}
	}

	public void ClearSelect()
	{
		SetSelectedColor(false);
	}

	public void SetSelectedColor(bool bSelect)
	{
		Image kImage = GetComponent<Image>();

		if(bSelect)
		{
			kImage.color = Color.green;
		}
		else
		{
			kImage.color = m_OriColor;
		}
	}
}
