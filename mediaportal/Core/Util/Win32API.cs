/* 
 *	Copyright (C) 2005 Team MediaPortal
 *	http://www.team-mediaportal.com
 *
 *  This Program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2, or (at your option)
 *  any later version.
 *   
 *  This Program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *   
 *  You should have received a copy of the GNU General Public License
 *  along with GNU Make; see the file COPYING.  If not, write to
 *  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA. 
 *  http://www.gnu.org/copyleft/gpl.html
 *
 */
using System;
using System.Runtime.InteropServices;

namespace MediaPortal.Util
{
	/// <summary>
	/// Summary description for Win32API.
	/// </summary>
	public static class Win32API
  {
    #region Interop declarations
	  
    #region Constants
    private const int SW_HIDE = 0;
    private const int SW_SHOWNORMAL = 1;
    private const int SW_SHOWMINIMIZED = 2;
    private const int SW_SHOWMAXIMIZED = 3;
    private const int SW_RESTORE = 9;
    private const int WPF_RESTORETOMAXIMIZED = 2;
	  public const int WM_SHOWWINDOW = 0x0018;
    #endregion

    #region Methods

//    [DllImportAttribute("kernel32", EntryPoint="RtlMoveMemory", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
//    public static extern void CopyMemory(ref KBDLLHOOKSTRUCT Destination, int Source, int Length);

 //   [DllImportAttribute("user32", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
 //   public static extern int GetKeyState(int nVirtKey);

//    [DllImportAttribute("user32", EntryPoint="SetWindowsHookExA", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
//    public static extern int SetWindowsHookEx(int idHook, LowLevelKeyboardDelegate lpfn, int hmod, int dwThreadId);

	  [DllImport("gdi32.dll", EntryPoint="CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32.dll", EntryPoint="SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc,IntPtr bmp);

		[DllImport("gdi32.dll", EntryPoint="DeleteDC")]
		public static extern IntPtr DeleteDC(IntPtr hDc);

    [DllImportAttribute("user32", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
    public static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref int lParam);

    [DllImportAttribute("user32", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
    public static extern int UnhookWindowsHookEx(int hHook);

    [DllImportAttribute("user32", EntryPoint="FindWindowA", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
    public static extern uint FindWindow([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClassName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpWindowName);

	  [DllImportAttribute("user32", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
    public static extern int GetWindow(int hwnd, int wCmd);

    [DllImport("user32", SetLastError = true)]
    private static extern uint GetWindowPlacement(uint _hwnd, [Out] out WindowPlacement _lpwndpl);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool PeekMessage([In, Out] ref MSG msg, IntPtr hwnd, int msgMin, int msgMax, int remove);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
    public static extern bool GetMessageW([In, Out] ref MSG msg, IntPtr hWnd, int uMsgFilterMin, int uMsgFilterMax);

    [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
    public static extern bool GetMessageA([In, Out] ref MSG msg, IntPtr hWnd, int uMsgFilterMin, int uMsgFilterMax);

    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern bool TranslateMessage([In, Out] ref MSG msg);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
    public static extern IntPtr DispatchMessageW([In] ref MSG msg);

    [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
    public static extern IntPtr DispatchMessageA([In] ref MSG msg);

    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern IntPtr GetParent(HandleRef hWnd);

    [DllImport("user32", SetLastError = true)]
    private static extern uint ShowWindow(uint _hwnd, int _showCommand);

    [DllImportAttribute("user32", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
    public static extern int EnableWindow(uint hwnd, int fEnable);

    [DllImport("user32", SetLastError = true)]
    private static extern uint SetForegroundWindow(uint _hwnd);

    [DllImport("user32", SetLastError = true)]
    public static extern bool PostThreadMessage(int idThread, uint Msg, uint wParam, uint lParam);
	  
    //[DllImport("wininet.dll")]
    //private extern static bool InternetGetConnectedState( out int Description, int ReservedValue ) ;

    #endregion

    #region Structures

    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
      public IntPtr hwnd;
      public int message;
      public IntPtr wParam;
      public IntPtr lParam;
      public int time;
      public int pt_x;
      public int pt_y;
    }

    /// <summary>
    /// Point struct used for GetWindowPlacement API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct Point
    {
      public int x;
      public int y;

      public Point(int _x, int _y)
      {
        x = _x;
        y = _y;
      }
    }

    /// <summary>
    /// Rect struct used for GetWindowPlacement API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct Rectangle
    {
      public int x;
      public int y;
      public int right;
      public int bottom;

      public Rectangle(int _x, int _y, int _right, int _bottom)
      {
        x = _x;
        y = _y;
        right = _right;
        bottom = _bottom;
      }
    }

    /// <summary>
    /// WindowPlacement struct used for GetWindowPlacement API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct WindowPlacement
    {
      public uint length;
      public uint flags;
      public uint showCmd;
      public Point minPosition;
      public Point maxPosition;
      public Rectangle normalPosition;
    }

    #endregion
	  
    #endregion


    //Checks if the computer is connected to the internet...
    public static bool IsConnectedToInternet( )
    {
#if DEBUG
      return true;
#else
      int Desc ;
      return InternetGetConnectedState( out Desc, 0 ) ;
#endif
    }
		
		public static bool IsConnectedToInternet(ref int code)
		{
#if DEBUG
      return true;
#else
			return InternetGetConnectedState( out code, 0 ) ;
#endif
		}

    public static void Show(string ClassName, string WindowName, bool bVisible)
    {
      uint i = FindWindow(ref ClassName, ref WindowName);
      if (bVisible)
      {
        ShowWindow(i, 5);
      }
      else
      {
        ShowWindow(i, 0);
      }
    }

    public static void Enable(string ClassName, string WindowName, bool bEnable)
    {
      uint i = FindWindow(ref ClassName, ref WindowName);
      if (bEnable)
      {
        EnableWindow(i, -1);
      }
      else
      {
        EnableWindow(i, 0);
      }
    }

    public static void ShowStartBar(bool bVisible)
    {
			try
			{
				Show("Shell_TrayWnd", "", bVisible);
			}
			catch(Exception){}
    }

    public static void EnableStartBar(bool bEnable)
    {
			try
			{
				Enable("Shell_TrayWnd", "", bEnable);
			}
			catch(Exception){}
    }
	  
    /// <summary> 
    /// Finds the specified window by its Process ID. Then brings it to 
    /// the foreground. 
    /// </summary> 
    /// <param name="_hWnd">Handle to the window to find and activate.</param> 
    public static void ActivateWindowByHandle(uint _hWnd)
    {
      WindowPlacement windowPlacement;
      GetWindowPlacement(_hWnd, out windowPlacement);

      switch (windowPlacement.showCmd)
      {
        case SW_HIDE:           //Window is hidden
          ShowWindow(_hWnd, SW_RESTORE);
          break;
        case SW_SHOWMINIMIZED:  //Window is minimized
          // if the window is minimized, then we need to restore it to its 
          // previous size. we also take into account whether it was 
          // previously maximized. 
          int showCmd = (windowPlacement.flags == WPF_RESTORETOMAXIMIZED) ? SW_SHOWMAXIMIZED : SW_SHOWNORMAL;
          ShowWindow(_hWnd, showCmd);
          break;
        default:
          // if it's not minimized, then we just call SetForegroundWindow to 
          // bring it to the front. 
          SetForegroundWindow(_hWnd);
          break;
      }
    }

  }
}
