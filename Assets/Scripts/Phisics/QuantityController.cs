using UnityEngine;
using UnityEngine.UI;

public class QuantityController : MonoBehaviour
{
	#region SIngleton:QuantityController

	public static QuantityController Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	#endregion

	[SerializeField] Text quantityDeadUiText;

	[System.Serializable]
	public class Quantity
	{
		public static int DeadQuantity { get; set; }
	}

    public void Update()
    {
		SetText();
    }

    public void SetText()
    {
		quantityDeadUiText.text = Quantity.DeadQuantity.ToString();
    }

	public void AddDeadQuantity()
    {
		Quantity.DeadQuantity++;
	}
}
