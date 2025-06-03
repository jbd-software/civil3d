using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

using ICMInterop.EntryPoints;
using ICMInterop.Shared;

namespace Civil3D.ICMInterop.Zones2D.Infrastructure;

public class AcadMessagePrinter : IMessagePrinter
{
	private readonly Editor _editor;

	public AcadMessagePrinter()
	{
		_editor = Application.DocumentManager.MdiActiveDocument.Editor;
	}

	public void Info(string message)
	{
		_editor.WriteMessage($"\n[INFO] {message}\n");
	}

	public void Error(string message)
	{
		_editor.WriteMessage($"\n[ERROR] {message}\n");
		Application.ShowAlertDialog($"An error occurred: {message}");
	}
}