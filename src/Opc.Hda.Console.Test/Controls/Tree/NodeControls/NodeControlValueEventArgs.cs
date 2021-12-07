namespace Opc.Hda.Controls.Tree.NodeControls
{
	public class NodeControlValueEventArgs : NodeEventArgs
	{
		private object _value;
		public object Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public NodeControlValueEventArgs(NodeControl control, TreeNodeAdv node)
			:base(node)
		{
		    this.NodeControl = control;
		}

	    public NodeControl NodeControl { get; set; }
	}
}
