//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Handles the spawning and returning of the ItemPackage
//
//=============================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.Events;
using UnityEditor;
using Valve.VR.InteractionSystem;

public class SwordSpawn : MonoBehaviour
{
	public ItemPackage itemPackage;

	[EnumFlags]
	public Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags;
	public string attachmentPoint;

	private GameObject spawnedItem;

	public Player player;


	//-------------------------------------------------
	void OnEnable()
	{
		SpawnAndAttachObject (player.hands[0]);
	}


	//-------------------------------------------------
	private void TakeBackItem( Hand hand )
	{
		RemoveMatchingItemsFromHandStack( itemPackage, hand );

		if ( itemPackage.packageType == ItemPackage.ItemPackageType.TwoHanded )
		{
			RemoveMatchingItemsFromHandStack( itemPackage, hand.otherHand );
		}
	}


	//-------------------------------------------------
	private ItemPackage GetAttachedItemPackage( Hand hand )
	{
		GameObject currentAttachedObject = hand.currentAttachedObject;

		if ( currentAttachedObject == null ) // verify the hand is holding something
		{
			return null;
		}

		ItemPackageReference packageReference = hand.currentAttachedObject.GetComponent<ItemPackageReference>();
		if ( packageReference == null ) // verify the item in the hand is matchable
		{
			return null;
		}

		ItemPackage attachedItemPackage = packageReference.itemPackage; // return the ItemPackage reference we find.

		return attachedItemPackage;
	}


	//-------------------------------------------------
	private void RemoveMatchingItemsFromHandStack( ItemPackage package, Hand hand )
	{
		for ( int i = 0; i < hand.AttachedObjects.Count; i++ )
		{
			ItemPackageReference packageReference = hand.AttachedObjects[i].attachedObject.GetComponent<ItemPackageReference>();
			if ( packageReference != null )
			{
				ItemPackage attachedObjectItemPackage = packageReference.itemPackage;
				if ( ( attachedObjectItemPackage != null ) && ( attachedObjectItemPackage == package ) )
				{
					GameObject detachedItem = hand.AttachedObjects[i].attachedObject;
					hand.DetachObject( detachedItem );
				}
			}
		}
	}


	//-------------------------------------------------
	private void RemoveMatchingItemTypesFromHand( ItemPackage.ItemPackageType packageType, Hand hand )
	{
		for ( int i = 0; i < hand.AttachedObjects.Count; i++ )
		{
			ItemPackageReference packageReference = hand.AttachedObjects[i].attachedObject.GetComponent<ItemPackageReference>();
			if ( packageReference != null )
			{
				if ( packageReference.itemPackage.packageType == packageType )
				{
					GameObject detachedItem = hand.AttachedObjects[i].attachedObject;
					hand.DetachObject( detachedItem );
				}
			}
		}
	}


	//-------------------------------------------------
	private void SpawnAndAttachObject( Hand hand )
	{
		if ( hand.otherHand != null )
		{
			//If the other hand has this item package, take it back from the other hand
			ItemPackage otherHandItemPackage = GetAttachedItemPackage( hand.otherHand );
			if ( otherHandItemPackage == itemPackage )
			{
				TakeBackItem( hand.otherHand );
			}
		}

		if ( itemPackage.otherHandItemPrefab != null )
		{
			if ( hand.otherHand.hoverLocked )
			{
				//Debug.Log( "Not attaching objects because other hand is hoverlocked and we can't deliver both items." );
				return;
			}
		}

		// if we're trying to spawn a one-handed item, remove one and two-handed items from this hand and two-handed items from both hands
		if ( itemPackage.packageType == ItemPackage.ItemPackageType.OneHanded )
		{
			RemoveMatchingItemTypesFromHand( ItemPackage.ItemPackageType.OneHanded, hand );
			RemoveMatchingItemTypesFromHand( ItemPackage.ItemPackageType.TwoHanded, hand );
			RemoveMatchingItemTypesFromHand( ItemPackage.ItemPackageType.TwoHanded, hand.otherHand );
		}

		// if we're trying to spawn a two-handed item, remove one and two-handed items from both hands
		else if ( itemPackage.packageType == ItemPackage.ItemPackageType.TwoHanded )
		{
			RemoveMatchingItemTypesFromHand( ItemPackage.ItemPackageType.OneHanded, hand );
			RemoveMatchingItemTypesFromHand( ItemPackage.ItemPackageType.OneHanded, hand.otherHand );
			RemoveMatchingItemTypesFromHand( ItemPackage.ItemPackageType.TwoHanded, hand );
			RemoveMatchingItemTypesFromHand( ItemPackage.ItemPackageType.TwoHanded, hand.otherHand );
		}

		spawnedItem = GameObject.Instantiate( itemPackage.itemPrefab );
		spawnedItem.SetActive( true );
		hand.AttachObject( spawnedItem, attachmentFlags, attachmentPoint );

		if ( ( itemPackage.otherHandItemPrefab != null ) )
		{
			GameObject otherHandObjectToAttach = GameObject.Instantiate( itemPackage.otherHandItemPrefab );
			otherHandObjectToAttach.SetActive( true );
			hand.otherHand.AttachObject( otherHandObjectToAttach, attachmentFlags );
		}
	}
}
