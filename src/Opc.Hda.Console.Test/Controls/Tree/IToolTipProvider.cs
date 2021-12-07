using Opc.Hda.Controls.Tree.NodeControls;

namespace Opc.Hda.Controls.Tree
{
	public interface IToolTipProvider
	{
		string GetToolTip(TreeNodeAdv node, NodeControl nodeControl);
	}
}
