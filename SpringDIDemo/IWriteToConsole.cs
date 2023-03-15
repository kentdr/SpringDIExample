using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringDIDemo
{
  public interface IWriteToConsole
  {
    void Write(string text);

    void WriteLine(string text);
  }
}
