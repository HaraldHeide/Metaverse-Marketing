/*
 * Imagedatabase
 * https://developers.google.com/ar/develop/java/augmented-images/guide
 * https://developers.google.com/ar/develop/unity/augmented-images/guide
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RESTClient;
using Azure.StorageServices;
using TMPro;
using GoogleARCore;

public class FromAzureBlobToAumentedImagesDb : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro Message;

    [Header("Azure Storage Service")]
    [SerializeField]
    private string storageAccount;
    [SerializeField]
    private string accessKey;
    [SerializeField]
    private string container;

    private StorageServiceClient client;
    private BlobService blobService;


    private List<Blob> items;

    public AugmentedImageDatabase augmentedImageDatabase;

    void Start()
    {
        Message.text = "Start";
        Init_Blob_Service();
    }

   
    void Init_Blob_Service()
    {
        if (string.IsNullOrEmpty(storageAccount) || string.IsNullOrEmpty(accessKey))
        {
            Message.text = "Storage account and access key are required\nEnter storage account and access key in Unity Editor";
        }

        client = StorageServiceClient.Create(storageAccount, accessKey);
        blobService = client.GetBlobService();
        ListBlobs();
    }

    public void ListBlobs()
    {
        Message.text =  "Listing blobs";
        StartCoroutine(blobService.ListBlobs(ListBlobsCompleted, container));
    }

    private void ListBlobsCompleted(IRestResponse<BlobResults> response)
    {
        if (response.IsError)
        {
            Message.text = "Failed to get list of blobs\nList blob error: " + response.ErrorMessage;
            return;
        }

        Message.text = "Loaded blobs: " + response.Data.Blobs.Length + "\nLoaded blobs: " + response.Data.Blobs.Length;

        foreach(Blob _blob in response.Data.Blobs)
        {
            BitArray bitArray;
            bitArray = Streamin
        }
        ////ReloadTable(response.Data.Blobs);

        ////Texture2D tex1 = Texture2D.Load;
        Texture2D tex = Texture2D.blackTexture;
        augmentedImageDatabase.AddImage("Truls", tex);

}
//void Update()
//    {
        
//    }
}
