using System.Drawing;
using System.Windows.Forms;

namespace Opc.Hda.Controls.Tree.Input
{
	internal class ResizeColumnState: ColumnState
	{
		private Point _initLocation;
		private int _initWidth;

		public ResizeColumnState(TreeViewAdv tree, TreeColumn column, Point p)
			: base(tree, column)
		{
			_initLocation = p;
			_initWidth = column.Width;
		}

		public override void KeyDown(KeyEventArgs args)
		{
			args.Handled = true;
			if (args.KeyCode == Keys.Escape)
				FinishResize();
		}

		public override void MouseDown(TreeNodeAdvMouseEventArgs args)
		{
		}

		public override void MouseUp(TreeNodeAdvMouseEventArgs args)
		{
			FinishResize();
		}

		private void FinishResize()
		{
			Tree.ChangeInput();
			Tree.FullUpdate();
			Tree.OnColumnWidthChanged(Column);
			Tree.OnColumnHeightChanged(Column);
		}

        public override bool MouseMove(MouseEventArgs args)
        {
			Column.Width = _initWidth + args.Location.X - _initLocation.X;
            Tree.UpdateView();
            return true;
        }

		public override void MouseDoubleClick(TreeNodeAdvMouseEventArgs args)
		{
			Tree.AutoSizeColumn(Column);
		}
	}
}
