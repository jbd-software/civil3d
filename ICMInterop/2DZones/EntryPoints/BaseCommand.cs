namespace ICMInterop.EntryPoints;

public abstract class BaseCommand
{
    /// <summary>
    /// 
    /// </summary>
    public void Exectute()
    {
        try
        {
            ExecuteCore();
        }
        catch (Exception ex)
        {
			var doc = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
			doc.Editor.WriteMessage($"\n[ERROR] {ex.Message}\n");
			Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog($"An error occurred: {ex.Message}");
		}
    }

	/// <summary>
	/// Subclasses must override this to implement actual command logic.
	/// </summary>
	protected abstract void ExecuteCore();
}
