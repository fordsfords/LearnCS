using System;
using System.Diagnostics;

namespace FordsFords.Assrts;

class Assrt {
  static int _assrtCount = 0;

  static public void IsTrue(bool test) {
    _assrtCount++;
    if (test) return;

    StackTrace st = new StackTrace(true);
    //StackFrame? frame = st.GetFrame(st.FrameCount - 1);
    StackFrame? frame = st.GetFrame(1);
    DateTimeOffset timeNow = DateTimeOffset.Now;

    if (frame != null) {
      Console.WriteLine($"Failed Assrt: {timeNow}, " +
        frame.GetFileName() + ":" + frame.GetFileLineNumber());
      Console.WriteLine($"Assrt Count: {_assrtCount}\n");
    } else {
      Console.WriteLine($"Failed Assrt: {timeNow}, unknown frame");
      Console.WriteLine($"Assrt Count: {_assrtCount}\n");
    }
    throw new ArgumentException("Failed Assrt");
  }

  static public int GetAssrtCount() {
    return _assrtCount;
  }


  static public void Fatal(string msg) {
    StackTrace st = new StackTrace(true);
    StackFrame? frame = st.GetFrame(st.FrameCount - 1);
    DateTimeOffset timeNow = DateTimeOffset.Now;

    if (frame != null) {
      Console.WriteLine($"Fatal error: {msg}: {timeNow}, " +
        frame.GetFileName() + ":" + frame.GetFileLineNumber());
      Console.WriteLine($"Assrt Count: {_assrtCount}\n");
    } else {
      Console.WriteLine($"Fatal error: {msg}: {timeNow}, unknown frame");
      Console.WriteLine($"Assrt Count: {_assrtCount}\n");
    }
    throw new ArgumentException(msg);
  }  // Fatal
}  // Assrt
