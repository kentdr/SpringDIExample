﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringDIDemo
{
  internal class WriteToConsole : IWriteToConsole
  {
    public void Write(string text)
    {
      Console.Write(text);
    }

    public void WriteLine(string text)
    {
      Console.WriteLine(text);
    }
  }
}
