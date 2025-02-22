﻿using System;
using System.Text;

public class Output
{
    private StringBuilder output;

    private bool isOutput = false;
    private int lineCount = 0;

    public Output()
    {
        this.output = new StringBuilder();
        this.isOutput = false;
        this.lineCount = 0;
    }

    /// <summary>
    /// output이 존재하는지 확인한다.
    /// </summary>
    /// <returns></returns>
    public bool IsReadable()
    {
        return this.isOutput;
    }

    public int LineofOutput()
    {
        return this.lineCount;
    }

    /// <summary>
    /// output을 입력하고 저장하며, 문자열 개수를 증가시키고, 읽을 수 있게 flag 설정한다.
    /// </summary>
    /// <param name="s"></param>
    public void AppendLine(string s)
    {
        this.isOutput = false;
        this.output.AppendLine(s);
        this.lineCount++;
    }

    /// <summary>
    /// Output Class의 IsReadable을 확인하고 호출할 것
    /// </summary>
    /// <returns></returns>
    public string OutputLines()
    {
        isOutput = false;

        return output.ToString();
    }

    /// <summary>
    /// 명령어 입력 전에 꼭 실행시켜 초기화 할것
    /// </summary>
    public void Clear()
    {
        this.output.Clear();
        this.lineCount = 0;
        UnsetIsOutput();
    }
   
    public void setIsOutput()
    {
        this.isOutput = true;
    }

    public void UnsetIsOutput()
    {
        this.isOutput = false;
    }
}
