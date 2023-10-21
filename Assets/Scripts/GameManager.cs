using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu]
public class GameManager : ScriptableObject
{
    [NonSerialized]
    private int playerScore = 0;

    [NonSerialized]
    private int computerScore = 0;

    public void Awake()
    {
        playerScore = computerScore = 0;
    }

    public void OnAfterDeserialize()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBeforeSerialize()
    {
        //throw new System.NotImplementedException();
    }

    internal void ComputerScore()
    {
        computerScore += 1;
    }

    internal string GetScore()
    {
        return $"{playerScore}:{computerScore}";
    }

    internal void PlayerScore()
    {
        playerScore += 1;
    }

    // Use this for initialization
    void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
			  
	}
}

