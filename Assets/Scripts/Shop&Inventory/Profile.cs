using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Profile : MonoBehaviour
{
	#region Singlton:Profile

	public static Profile Instance;

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

	public class Avatar
	{
		public Sprite Image;
		public Animation Anim;
		public int Index;
	}
	
	[SerializeField] GameObject AvatarUITemplate;
	public List<Avatar> AvatarsList;

	[System.Serializable]
	public class ProfileItem
	{
		public static int Index { get; set; }
		/*public static int IndexZ { get; set; }*/
	}

	public List<ProfileItem> ProfileItemList;

	[SerializeField] Transform AvatarsScrollView;

	GameObject g;
    int newSelectedIndex { get; set; }
    int previousSelectedIndex { get; set; }

    [SerializeField] Color ActiveAvatarColor;
    [SerializeField] Color DefaultAvatarColor;

    [SerializeField] Image CurrentAvatar;

    void Start ()
	{
		GetAvailableAvatars ();
        newSelectedIndex = previousSelectedIndex = 0;
	}

	void Update()
    {

    }

	void GetAvailableAvatars ()
	{
		for (int i = 0; i < Shop.Instance.ShopItemsList.Count; i++) {
			if (Shop.Instance.ShopItemsList [i].IsPurchased) {
                //add all purchased avatars to AvatarsList
                AddAvatar(Shop.Instance.ShopItemsList[i].Image);
            }
		}
		SelectAvatar (newSelectedIndex);
	}

	public void AddAvatar (Sprite img)
	{
		if (AvatarsList == null)
			AvatarsList = new List<Avatar> ();
		
		Avatar av = new Avatar (){ Image = img };
		//add av to AvatarsList
		AvatarsList.Add (av);

		//add avatar in the UI scroll view
		g = Instantiate (AvatarUITemplate, AvatarsScrollView);
		g.transform.GetChild (0).GetComponent <Image> ().sprite = av.Image;

        //add click event
        g.transform.GetComponent<Button>().AddEventListener(AvatarsList.Count - 1, OnAvatarClick);//!!!!!!!!!!!!!!!!!
	}

    /*	public void AddM(int Index)
        {
            AddIndex(Index);
            Debug.Log(ProfileItem.Index);
        }*/

    public void AddIndex(int Index)
    {
		ProfileItem.Index = Index;
        g.transform.GetComponent<Button>().AddEventListener(ProfileItem.Index, AddIndex);
        Debug.Log(Index);
    }

    /*    public void Aa(int Index)
        {
            Debug.Log("m");
        }*/

    void OnAvatarClick (int AvatarIndex)
	{
		SelectAvatar (AvatarIndex);
	}

void SelectAvatar (int AvatarIndex)
	{
        previousSelectedIndex = newSelectedIndex;
        newSelectedIndex = AvatarIndex;
/*        ProfileItem.Index = lol;*/
        AvatarsScrollView.GetChild(previousSelectedIndex).GetComponent<Image>().color = DefaultAvatarColor;
        AvatarsScrollView.GetChild(newSelectedIndex).GetComponent<Image>().color = ActiveAvatarColor;
        //Change Avatar
        CurrentAvatar.sprite = AvatarsList[newSelectedIndex].Image;
	}
}
