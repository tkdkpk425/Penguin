using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour 
{
	
	public float minSwipeDistY;
	
	public float minSwipeDistX;

	public Text Swipe;
	public Image leftImage;
	public Image centerImage;
	public Image rightImage;
	public Text charDescription;
	private Vector2 startPos;
	private int[] charNums;
	void Start() 
	{
		Swipe.text = "default";
		charNums = new int[]{0,1,2,3,4};
	}
	void Update()
	{
		//#if UNITY_ANDROID
		if (Input.touchCount > 0) 
			
		{
			
			Touch touch = Input.touches[0];
			
			
			
			switch (touch.phase) 
				
			{
				
			case TouchPhase.Began:
				
				startPos = touch.position;
				
				break;
				
				
				
			case TouchPhase.Ended:
				
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
				
				if (swipeDistVertical > minSwipeDistY) 
					
				{
					
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
					
					if (swipeValue > 0)//up swipe
					{

					} else if (swipeValue < 0)//down swipe
					{}		
							//Shrink ();
							
				}
				
				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				
				if (swipeDistHorizontal > minSwipeDistX) 
				{
					
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					
					if (swipeValue > 0) {//right swipe
						Swipe.text = "moving right";
					} else if (swipeValue < 0)//left swipe
					{		
							//MoveLeft ();
						Swipe.text = "moving left";
					}
					
				}
				break;
			}
		}
	}
}