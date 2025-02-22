﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Repository
{
    public Branch[] branch;
}

[System.Serializable]
public class Branch
{
    public string title;
    public string[] author;
}

[System.Serializable]
public class Author
{
    public string[] name;
}